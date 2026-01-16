using System;
using System.Net;
using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.EnvDTE.Host.Callback;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.Rd;
using JetBrains.Rd.Impl;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host
{
    [PublicAPI]
    public class ConnectionManager
    {
        private const string Host = "EnvDTE Communication Host";
        private const string Protocol = "EnvDTE Communication Protocol";
        public int Port { get; private set; }

        public ConnectionManager(Lifetime lifetime, [NotNull] ISolution solution) => SetupModel(lifetime, solution);

        private void SetupModel(Lifetime lifetime, ISolution solution)
        {
            SingleThreadScheduler.RunOnSeparateThread(lifetime, Host, scheduler =>
            {
                var serverFactory = new ProtocolFactory(lifetime, scheduler, Host);
                Port = serverFactory.localPort;

                serverFactory.connected.View(lifetime, (connectionLifetime, protocol) =>
                {
                    scheduler.Queue(() =>
                    {
                        var model = new DteProtocolModel(connectionLifetime, protocol);
                        RegisterCallbacks(model, scheduler, solution);
                    });
                });

            });
        }

        private static void RegisterCallbacks([NotNull] DteProtocolModel model, [NotNull] IScheduler scheduler, [NotNull] ISolution solution)
        {
            foreach (var provider in solution.GetComponents2<IEnvDteCallbackProvider>())
            {
                provider.RegisterCallbacks(model, scheduler);
            }
        }
    }

    // TODO: Move to a common place and make sure that reusing the protocol this way is safe
    public class ProtocolFactory
    {
        public readonly int localPort;
        public readonly IViewableSet<Protocol> connected = new ViewableSet<Protocol>();

        public ProtocolFactory(Lifetime lifetime, IScheduler scheduler, string id, IPEndPoint? endpoint = null)
            : this(lifetime, () => new SocketWire.WireParameters(scheduler, id), endpoint) {}

        public ProtocolFactory(
            Lifetime lifetime,
            Func<SocketWire.WireParameters> wireParametersFactory,
            IPEndPoint? endpoint = null
        )
        {
            var serverSocket = SocketWire.Server.CreateServerSocket(endpoint);
            var serverSocketLifetimeDef = new LifetimeDefinition(lifetime);
            serverSocketLifetimeDef.Lifetime.OnTermination(() =>
            {
                SocketWire.Base.CloseSocket(serverSocket);
            });
            localPort = ((IPEndPoint) serverSocket.LocalEndPoint).Port;

            void Rec()
            {
                lifetime.TryExecute(() =>
                {
                    var (scheduler, id) = wireParametersFactory();
                    var s = new SocketWire.Server(lifetime, scheduler, serverSocket, id);

                    // Create one protocol per server, this way server instances can be reused for multiple client connections
                    var proto = new Protocol($"{s.Id}-Protocol", new Serializers(), new Identities(IdKind.Server), scheduler, s, lifetime);

                    // Each server will spawn a thread that will be waiting in serverSocket.Accept method. When lifetime
                    // termination is invoked, these threads synchronously join the termination thread. Since these Thread.Join
                    // calls are located deeper in the Lifetime termination stack we have to place this socket termination call
                    // after each server creation.
                    lifetime.OnTermination(() => serverSocketLifetimeDef.Terminate());

                    s.Connected.WhenTrue(lifetime, lt =>
                    {
                        connected.AddLifetimed(lt, proto);
                        Rec();
                    });
                });
            }

            Rec();
        }
    }
}
