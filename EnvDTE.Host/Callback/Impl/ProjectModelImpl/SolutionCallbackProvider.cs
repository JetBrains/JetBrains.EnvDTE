using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.DataFlow;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Features.SolutionBuilders;
using JetBrains.ProjectModel.Features.SolutionBuilders.Prototype.Services.Execution;
using JetBrains.ProjectModel.SolutionStructure.SolutionConfigurations;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class SolutionCallbackProvider(
        Lifetime componentLifetime,
        ISolution solution,
        ProjectModelViewHost host,
        ISolutionBuilder builder,
        ISolutionConfigurationHolder configurationHolder)
        : IEnvDteCallbackProvider
    {
        private const string ActiveConfigProperty = "ActiveConfig";
        private const string PathProperty = "Path";
        private const string NameProperty = "Name";
        private const string StartupProjectProperty = "StartupProject";
        private const string DescriptionProperty = "Description";
        private const string ProjectDependenciesProperty = "ProjectDependencies";

        public void RegisterCallbacks(DteProtocolModel model)
        {
            model.Solution_FileName.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => solution.SolutionFilePath.FullPath));

            model.Solution_Count.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => GetFilteredProjects().Count()));

            model.Solution_Item.SetAsync(async (lifetime, index) =>
            {
                var projects = await lifetime.StartReadActionAsync(() => GetFilteredProjects().ToArray());
                return index >= projects.Length ? null : projects.ElementAt(index);
            });

            model.Solution_get_Projects.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => GetFilteredProjects().AsList()));

            model.Solution_get_Property.SetWithSolutionMarkSync(solution, (name, solutionMark) => name switch
            {
                ActiveConfigProperty => solutionMark.ActiveConfigurationAndPlatform switch
                {
                  SolutionConfigurationAndPlatform config => $"{config.Configuration}|{config.Platform}",
                  _ => null
                },
                PathProperty => solution.SolutionFilePath.FullPath,
                NameProperty => solution.Name,
                StartupProjectProperty => null, // TODO
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
                        break; // TODO
                    default:
                        throw new ArgumentOutOfRangeException(nameof(req.Name));
                }
            });

            model.Solution_build.SetSync((lifetime, req) =>
            {
                var request = builder.CreateBuildRequest(
                    req.BuildSessionTarget.FromRdBuildSessionTarget(),
                    null,
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

        // Misc project is also displayed in VS and our approach of using item id does not allow that because it doesn't
        // have a unique id. In the future it would be better to start using project guids instead, but since that complicates
        // the client side, I'm not going to do it now.
        private IEnumerable<ProjectItemModel> GetFilteredProjects() => solution.GetAllProjects()
            .Where(p => p.ParentFolder is null)
            .Select(host.GetIdByItem)
            .Where(id => id != 0)
            .Select(id => new ProjectItemModel(id));
    }
}
