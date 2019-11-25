using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.EnvDTE.Host.Callback;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.Rd;
using JetBrains.Rd.Impl;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host
{
    [PublicAPI]
    public sealed class ConnectionManager
    {
        private const string Host = "T4 Communication Host";
        private const string Protocol = "T4 Communication Protocol";
        public int Port { get; private set; }
        private IReadOnlyList<IEnvDteCallbackProvider> CallbackProviders { get; }

        public ConnectionManager(Lifetime lifetime, [NotNull] ISolution solution)
        {
            var host = solution.GetComponent<ProjectModelViewHost>();
            var model = SetupModel(lifetime);
            RegisterCallbacks(model, host, solution);
        }

        [NotNull]
        private DteProtocolModel SetupModel(Lifetime lifetime)
        {
            var scheduler = SingleThreadScheduler.RunOnSeparateThread(lifetime, Host);
            var server = new SocketWire.Server(lifetime, scheduler);
            Port = server.Port;
            var serializers = new Serializers();
            var identities = new Identities(IdKind.Server);
            var protocol = new Protocol(Protocol, serializers, identities, scheduler, server, lifetime);
            return new DteProtocolModel(lifetime, protocol);
        }

        private void RegisterCallbacks(
            [NotNull] DteProtocolModel model,
            [NotNull] ProjectModelViewHost host,
            [NotNull] ISolution solution
        )
        {
            foreach (var provider in solution.GetComponents<IEnvDteCallbackProvider>())
            {
                provider.RegisterCallbacks(solution, host, model);
            }
        }
    }
}
