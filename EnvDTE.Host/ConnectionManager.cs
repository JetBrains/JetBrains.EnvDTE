using System;
using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.Rd;
using JetBrains.Rd.Impl;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host
{
    [PublicAPI]
    public sealed class ConnectionManager
    {
        private const string Host = "T4 Communication Host";
        private const string Protocol = "T4 Communication Protocol";

        [NotNull]
        public ISolution Solution { get; }

        public ConnectionManager(Lifetime lifetime, [NotNull] ISolution solution)
        {
            Solution = solution;
            var model = SetupModel(lifetime);
            RegisterCallbacks(model);
        }

        [NotNull]
        private static DteProtocolModel SetupModel(Lifetime lifetime)
        {
            var scheduler = SingleThreadScheduler.RunOnSeparateThread(lifetime, Host);
            var server = new SocketWire.Server(lifetime, scheduler);
            var serializers = new Serializers();
            var identities = new Identities(IdKind.Server);
            var protocol = new Protocol(Protocol, serializers, identities, scheduler, server, lifetime);
            return new DteProtocolModel(lifetime, protocol);
        }

        private void RegisterCallbacks([NotNull] DteProtocolModel model)
        {
            model.DTE_Name.Set(_ => "JetBrains Rider");
            model.DTE_Name.Set(_ => FileSystemPath
                .Parse(AppDomain.CurrentDomain.BaseDirectory)
                .Combine(AppDomain.CurrentDomain.FriendlyName)
                .FullPath
            );
            model.DTE_CommandLineArgs.Set(_ => Environment.GetCommandLineArgs().AggregateString(" "));
            model.Solution_FileName.Set(_ => Solution.SolutionFilePath.FullPath);
        }
    }
}
