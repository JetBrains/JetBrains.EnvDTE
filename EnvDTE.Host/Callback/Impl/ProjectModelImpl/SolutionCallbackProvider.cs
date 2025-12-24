using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.DataFlow;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.Platform.RdFramework.Impl;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Features.SolutionBuilders;
using JetBrains.ProjectModel.Features.SolutionBuilders.Prototype.Services.Execution;
using JetBrains.ProjectModel.SolutionStructure.SolutionConfigurations;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Feature.Services.Protocol;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Threading;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class SolutionCallbackProvider(
        Lifetime componentLifetime,
        ILogger logger,
        ISolution solution,
        ProjectModelViewHost viewHost,
        ISolutionBuilder builder,
        ISolutionConfigurationHolder configurationHolder,
        ShellRdDispatcher rdDispatcher)
        : IEnvDteCallbackProvider
    {
        private const string ActiveConfigProperty = "ActiveConfig";
        private const string PathProperty = "Path";
        private const string NameProperty = "Name";
        private const string StartupProjectProperty = "StartupProject";
        private const string DescriptionProperty = "Description";
        private const string ProjectDependenciesProperty = "ProjectDependencies";

        private IProject[] _startupProjects = [];

        public void RegisterCallbacks(DteProtocolModel model)
        {
            rdDispatcher.Queue(() =>
            {
                var runConfigurationModel = solution.GetProtocolSolution().GetRunConfigurationModel();
                runConfigurationModel.SelectedRunConfigurationProjectPaths
                    .Advise(componentLifetime, paths => componentLifetime.StartReadActionAsync(() =>
                    {
                        var pathSet = paths.ToSet();
                        _startupProjects = solution.GetAllProjects()
                            .Where(p => pathSet
                                .Contains(p.ProjectFileLocation.NormalizeSeparators(FileSystemPathEx.SeparatorStyle.Unix)))
                            .ToArray();

                        if (_startupProjects.Length < paths.Count)
                        {
                            logger.Warn(
                                "Not all run configuration projects were able to be resolved by startup projects listener. " +
                                "Run configuration might contain deleted projects.");
                        }
                    }).NoAwait());
            });

            model.Solution_FileName.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => solution.SolutionFilePath.FullPath));

            model.Solution_Count.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => GetFilteredProjects().Count()));

            model.Solution_Item.SetAsync(async (lifetime, index) =>
            {
                var projects = await lifetime.StartReadActionAsync(() =>
                    GetFilteredProjects().Select(p => new ProjectItemModel(viewHost.GetIdByItem(p))).ToArray());
                return index >= projects.Length ? null : projects.ElementAt(index);
            });

            model.Solution_get_Projects.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => GetFilteredProjects()
                    .Select(p => new ProjectItemModel(viewHost.GetIdByItem(p))).AsList()));

            model.Solution_get_Property.SetWithSolutionMarkAsync(solution, async (lifetime, name, solutionMark) => name switch
            {
                ActiveConfigProperty => solutionMark.ActiveConfigurationAndPlatform switch
                {
                    SolutionConfigurationAndPlatform config => $"{config.Configuration}|{config.Platform}",
                    _ => null
                },
                PathProperty => solution.SolutionFilePath.FullPath,
                NameProperty => solution.Name,
                StartupProjectProperty => await GetStartupProjectPropertyValueAsync(lifetime),
                DescriptionProperty => solutionMark.GetSolutionDescription(),
                ProjectDependenciesProperty => null, // In VS always returns null
                _ => throw new ArgumentOutOfRangeException(nameof(name))
            });

            model.Solution_set_Property.SetVoidAsync(async (lifetime, req) =>
            {
                switch (req.Name)
                {
                    case ActiveConfigProperty:
                        await lifetime.StartMainRead(() => solution.SetActiveConfigurationAndPlatform(req.Value));
                        break;
                    case NameProperty:
                        await lifetime.StartMainWrite(() => solution.RenameSolution(req.Value));
                        break;
                    case DescriptionProperty:
                        await lifetime.StartMainWrite(() => solution.SetSolutionDescription(req.Value));
                        break;
                    case StartupProjectProperty:
                        throw new NotImplementedException();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(req.Name));
                }
            });

            // Only visible items can be queried with this method.
            // The argument can either be a full path or an item name
            model.Solution_find_ProjectItem.SetAsync(async (lifetime, arg) =>
            {
                var path = VirtualFileSystemPath.TryParse(arg, InteractionContext.SolutionContext);

                var (projectItem, containingProject) = await lifetime.StartReadActionAsync(() =>
                {
                    if (path.IsNotEmpty && path.IsAbsolute)
                    {
                        var item = solution.FindProjectItemsByLocation(path).FirstOrDefault();
                        return (item, item?.GetProject());
                    }

                    foreach (var project in GetFilteredProjects())
                    {
                        var visitor = new FindProjectItemVisitor(arg);
                        project.Accept(visitor);

                        if (visitor.ProjectItem is not null)
                        {
                            logger.Assert(visitor.ContainingProject is not null, "Containing project should not be null.");
                            return (visitor.ProjectItem, visitor.ContainingProject);
                        }
                    }

                    return (null, null);
                });

                return projectItem?.ToRdFindProjectItemResponse(containingProject, viewHost);
            });

            model.Solution_get_StartupProjects.SetAsync(async (lifetime, _) =>
            {
                var namesTask = await lifetime.StartReadActionAsync(() =>
                    Task.WhenAll(_startupProjects.Select(p => p.GetVSUniqueNameAsync(lifetime)))
                );
                return (await namesTask).ToList();
            });

            model.Solution_build.SetSync((lifetime, req) =>
            {
                var request = builder.CreateBuildRequest(
                    req.BuildSessionTarget.FromRdBuildSessionTarget(),
                    [],
                    SolutionBuilderRequestSilentMode.Default);

                componentLifetime.OnTermination(() => request.Abort());
                builder.ExecuteBuildRequest(request);

                if (req.WaitForBuild)
                    request.State.WaitForValue(lifetime, state => state.HasFlag(BuildRunState.Completed));

                return Unit.Instance;
            });

            model.Solution_get_BuildState.SetSync(_ =>
                builder.RunningRequest.Value is null
                    ? RdBuildState.NotStarted
                    : builder.RunningRequest.Value.State.Value == BuildRunState.Completed
                        ? RdBuildState.Done
                        : RdBuildState.InProgress);

            // Returns the number of projects that failed to build
            model.Solution_get_LastBuildInfo.SetSync(_ => builder.RunningRequest.Value?.GetAllBuildErrors()
                .Select(e => e.ProjectId).Distinct().Count() ?? 0);

            model.Solution_get_ActiveConfiguration.SetSync(_ =>
                configurationHolder.GetSolutionActiveConfiguration() switch
                {
                    SolutionConfigurationAndPlatform config => config.ToRdSolutionConfiguration(),
                    _ => null
                });

            model.Solution_set_ActiveConfiguration.SetVoidAsync((lifetime, config) =>
                lifetime.StartMainRead(() => solution.SetActiveConfigurationAndPlatform(config.FromRdSolutionConfiguration())));

            model.Solution_get_ConfigurationCount.SetWithSolutionMarkSync(solution, (_, solutionMark) =>
                solutionMark.ConfigurationAndPlatformStore.ConfigurationsAndPlatforms.Count);

            model.Solution_get_ConfigurationByIndex.SetWithSolutionMarkSync(solution, (index, solutionMark) =>
                solutionMark.ConfigurationAndPlatformStore.ConfigurationsAndPlatforms.ElementAt(index)
                    .ToRdSolutionConfiguration());

            model.Solution_get_ConfigurationByName.SetWithSolutionMarkSync(solution, (name, solutionMark) =>
                solutionMark.ConfigurationAndPlatformStore.ConfigurationsAndPlatforms
                    .FirstOrDefault(cp => cp.Configuration.Equals(name, StringComparison.OrdinalIgnoreCase))
                    ?.ToRdSolutionConfiguration());
        }

        private async Task<string> GetStartupProjectPropertyValueAsync(Lifetime lifetime)
        {
            /*
             * The `StartupProject` solution property can have different values:
             *  - If there are multiple startup projects, the value is "<Multiple Projects>"
             *  - If there is a single startup project and the name is unambiguous, the value is the project's (short) name
             *  - If there is a single startup project and the name is ambiguous
             *    - For the top level projects, the value is the project's (short) name
             *    - For projects inside solution folders, the value is "<project-name> (<project-path-chain>)"
             */

            if (_startupProjects.Length == 0) return string.Empty;
            if (_startupProjects.Length > 1) return "<Multiple Projects>";

            var project = _startupProjects[0];
            return await lifetime.StartReadActionAsync(() =>
            {
                if (solution.GetProjectsByName(project.Name).Count() == 1 || project.ParentFolder is null)
                    return project.Name;

                var pathChain = string.Join("\\", project.GetPathChain().Reverse().Select(f => f.Name));
                return $"{project.Name} ({pathChain})";
            });
        }

        // Misc project is also displayed in VS, but our approach of using item id does not allow that because it doesn't
        // have a unique id. In the future it would be better to start using project guids instead, but since that complicates
        // the client side, I'm not going to do it now.
        private IEnumerable<IProject> GetFilteredProjects() => solution.GetTopLevelProjects()
            .Where(p => p.IsProjectFromUserView() || p.IsSolutionFolder());

        private class FindProjectItemVisitor(string name) : RecursiveProjectVisitor
        {
            private bool _projectItemFound;

            public override bool ProcessingIsFinished => _projectItemFound;

            [CanBeNull] public IProject ContainingProject { get; private set; }
            [CanBeNull] public IProjectItem ProjectItem { get; private set; }

            public override void VisitProjectItem(IProjectItem projectItem)
            {
                var isHidden = projectItem switch
                {
                    IProjectFile file => file.Properties.IsHidden,
                    ProjectImpl => false, // Ignore project folders
                    ProjectFolderImpl folder => folder.IsHidden,
                    _ => true
                };

                if (!isHidden && projectItem.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    ProjectItem = projectItem;
                    _projectItemFound = true;
                }
            }

            public override void VisitProject(IProject project)
            {
                if (!ProcessingIsFinished)
                {
                    ContainingProject = project;
                }

                base.VisitProject(project);
            }
        }
    }
}
