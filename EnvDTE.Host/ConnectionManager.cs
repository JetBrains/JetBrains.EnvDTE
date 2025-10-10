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
    public sealed class ConnectionManager
    {
        private const string Host = "EnvDTE Communication Host";
        private const string Protocol = "EnvDTE Communication Protocol";
        private IReadOnlyList<IEnvDteCallbackProvider> CallbackProviders { get; }
        public int Port { get; private set; }

        public ConnectionManager(Lifetime lifetime, [NotNull] ISolution solution) => SetupModel(lifetime, solution);

        private void SetupModel(Lifetime lifetime, ISolution solution)
        {
            var scheduler = SingleThreadScheduler.RunOnSeparateThread(lifetime, Host);
            var server = new SocketWire.Server(lifetime, scheduler);
            Port = server.Port;
            var serializers = new Serializers();
            var identities = new Identities(IdKind.Server);
            scheduler.Queue(() =>
            {
                var protocol = new Protocol(Protocol, serializers, identities, scheduler, server, lifetime);
                var model = new DteProtocolModel(lifetime, protocol);
                RegisterCallbacks(model, solution);
            });
        }

        private void RegisterCallbacks([NotNull] DteProtocolModel model, [NotNull] ISolution solution)
        {
            foreach (var provider in solution.GetComponents2<IEnvDteCallbackProvider>())
            {
                provider.RegisterCallbacks(model);
            }
        }
    }
}
