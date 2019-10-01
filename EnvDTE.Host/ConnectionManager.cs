using System;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.Core;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.Rd;
using JetBrains.Rd.Impl;
using JetBrains.ReSharper.Host.Features.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
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

        public int Port { get; private set; }

        [NotNull]
        private ProjectModelViewHost ProjectModelViewHost { get; }

        public ConnectionManager(Lifetime lifetime, [NotNull] ISolution solution)
        {
            Solution = solution;
            ProjectModelViewHost = Solution.GetComponent<ProjectModelViewHost>();
            var model = SetupModel(lifetime);
            RegisterCallbacks(model);
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

        private void RegisterCallbacks([NotNull] DteProtocolModel model)
        {
            RegisterDTECallbacks(model);
            RegisterSolutionCallbacks(model);
            RegisterProjectCallbacks(model);
        }

        private void RegisterProjectCallbacks([NotNull] DteProtocolModel model)
        {
            model.Project_get_Name.Set(projectModel =>
                ProjectModelViewHost.GetItemById<IProject>(projectModel.Id)?.Name ?? "");
            model.Project_set_Name.Set(request =>
            {
                string name = request.NewName;
                var project = ProjectModelViewHost.GetItemById<IProject>(request.Model.Id);
                if (project == null) return Unit.Instance;
                Solution.InvokeUnderTransaction(cookie => cookie.Rename(project, name));
                return Unit.Instance;
            });
            model.Project_get_FileName.Set(projectModel =>
                ProjectModelViewHost.GetItemById<IProject>(projectModel.Id)?.ProjectFile?.Name ?? "");
            model.Project_Delete.Set(projectModel =>
            {
                var project = ProjectModelViewHost.GetItemById<IProject>(projectModel.Id);
                if (project == null) return Unit.Instance;
                Solution.InvokeUnderTransaction(cookie => cookie.Remove(project));
                return Unit.Instance;
            });
        }

        private void RegisterSolutionCallbacks([NotNull] DteProtocolModel model)
        {
            model.Solution_FileName.Set(_ => Solution.SolutionFilePath.FullPath);
            model.Solution_Count.Set(_ => Solution.GetAllProjects().Count);
            model.Solution_Item.Set(index =>
            {
                var projects = Solution.GetAllProjects();
                if (projects.Count >= index) return new Rider.Model.ProjectModel(-1);
                var project = projects.ElementAt(index + 1);
                int id = ProjectModelViewHost.GetIdByItem(project);
                return new Rider.Model.ProjectModel(id);
            });
            model.Solution_get_Projects.Set(_ => Solution
                .GetAllProjects()
                .Select(ProjectModelViewHost.GetIdByItem)
                .Select(id => new Rider.Model.ProjectModel(id))
                .AsList());
        }

        private static void RegisterDTECallbacks([NotNull] DteProtocolModel model)
        {
            model.DTE_Name.Set(_ => "JetBrains Rider");
            model.DTE_Name.Set(_ => FileSystemPath
                .Parse(AppDomain.CurrentDomain.BaseDirectory)
                .Combine(AppDomain.CurrentDomain.FriendlyName)
                .FullPath
            );
            model.DTE_CommandLineArgs.Set(_ => Environment.GetCommandLineArgs().AggregateString(" "));
        }
    }
}
