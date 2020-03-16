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

        private void RegisterCallbacks(
            [NotNull] DteProtocolModel model,
            [NotNull] ISolution solution
        )
        {
            var host = solution.GetComponent<ProjectModelViewHost>();
            foreach (var provider in solution.GetComponents<IEnvDteCallbackProvider>())
            {
                provider.RegisterCallbacks(solution, host, model);
            }
        }
    }
}
