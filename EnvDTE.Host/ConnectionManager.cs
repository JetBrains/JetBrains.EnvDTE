using System.Collections.Generic;
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
                var serverFactory = new SocketWire.ServerFactory(lifetime, scheduler);
                Port = serverFactory.LocalPort;

                serverFactory.Connected.View(lifetime, (connectionLifetime, server) =>
                {
                    var serializers = new Serializers();

                    var protocol = new Protocol(Protocol, serializers, new Identities(IdKind.Server),
                        scheduler, server, connectionLifetime);

                    scheduler.Queue(() =>
                    {
                        var model = new DteProtocolModel(connectionLifetime, protocol);
                        RegisterCallbacks(model, solution);
                    });
                });

            });
        }

        private static void RegisterCallbacks([NotNull] DteProtocolModel model, [NotNull] ISolution solution)
        {
            foreach (var provider in solution.GetComponents2<IEnvDteCallbackProvider>())
            {
                provider.RegisterCallbacks(model);
            }
        }
    }
}
