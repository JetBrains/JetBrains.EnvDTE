using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.EnvDTE.Host.Callback;
using JetBrains.EnvDTE.Host.Manager;
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
                RegisterCallbacks(lifetime, model, solution);
            });
        }

        private void RegisterCallbacks(
            Lifetime lifetime,
            [NotNull] DteProtocolModel model,
            [NotNull] ISolution solution
        )
        {
            var host = solution.GetComponent<ProjectModelViewHost>();
            // This manager will be stored in closures of callbacks.
            // Since the entire protocol will be deleted on file execution end,
            // this shouldn't cause memory leaks
            var astManager = new AstManager();
            foreach (var provider in solution.GetComponents<IEnvDteCallbackProvider>())
            {
                provider.RegisterCallbacks(astManager, solution, host, model);
            }
        }
    }
}
