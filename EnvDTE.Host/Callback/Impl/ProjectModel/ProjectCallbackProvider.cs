using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Application.Components;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.Platform.MsBuildHost.Models;
using JetBrains.Platform.MsBuildHost.Utils;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost;
using JetBrains.ProjectModel.ProjectsHost.Impl;
using JetBrains.ProjectModel.ProjectsHost.MsBuild;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost;
using JetBrains.ProjectModel.Properties;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.RdBackend.Common.Features.ProjectModel.View.EditProperties.Solutions;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Threading;
using JetBrains.Util;
using Key = JetBrains.Util.Key;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class ProjectCallbackProvider(
        Lifetime componentLifetime,
        ILogger logger,
        ISolution solution,
        ProjectModelViewHost host,
        MsBuildProjectsConfigurationsStore configurationsStore)
        : IEnvDteCallbackProvider
    {
        private const string SolutionFolderProjectGuid = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
        private readonly Key _uniqueNameKey = new("EnvDTE.UniqueName");

        public void RegisterCallbacks(DteProtocolModel model)
        {
            model.Project_get_Name.SetWithReadLock(solution.Locks,
                projectModel => GetProject(projectModel)?.Name ?? string.Empty);

            model.Project_set_Name.SetWithReadLock(solution.Locks, request =>
            {
                var name = request.NewName;
                var project = GetProject(request.Model);
                if (project is null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Rename(project, name));
                return Unit.Instance;
            });

            model.Project_get_FileName.SetWithReadLock(solution.Locks, projectModel =>
                GetProject(projectModel)?.ProjectFileLocation.FullPath ?? string.Empty);

            model.Project_get_UniqueName.SetAsync(async (lifetime, projectModel) =>
            {
                var project = GetProject(projectModel);
                if (project is null) return string.Empty;

                string uniqueName = null;
                await lifetime.StartReadActionAsync(() =>
                {
                    uniqueName = project.GetProperty(_uniqueNameKey) as string;
                });
                if (uniqueName is not null) return uniqueName;

                uniqueName = CalculateProjectUniqueName(project);
                // Save the unique name to the project properties so we don't have to calculate it every time
                await lifetime.StartMainWrite(() => project.SetProperty(_uniqueNameKey, uniqueName));
                return uniqueName;
            });

            model.Project_get_Kind.SetSync(projectModel =>
            {
                var project = GetProject(projectModel);
                if (project is null) return string.Empty;

                if (project.ProjectProperties.ProjectKind == ProjectKind.SOLUTION_FOLDER) return SolutionFolderProjectGuid;

                var guid = project.ProjectProperties.ProjectTypeGuids.FirstOrDefault();
                return guid.ToString("B").ToUpperInvariant();
            });

            model.Project_get_Property.SetAsync(async (lifetime, args) =>
            {
                var project = GetProject(args.Model);
                if (project is null) return null;

                string value = null;
                await lifetime.StartReadActionAsync(() =>
                {
                    value = project.GetRequestedProjectProperty(project.GetCurrentTargetFrameworkId(), args.Name);
                });
                return value;
            });

            model.Project_set_Property.SetVoidAsync(async (lifetime, args) =>
            {
                var projectMark = GetProject(args.Model)?.GetProjectMark();
                if (projectMark is null) return;

                logger.Assert(!projectMark.IsVCXProject(), "Properties of C++ projects cannot be changed this way");

                var projectHostContainer = solution.ProjectsHostContainer();
                var projectHost = projectHostContainer.GetComponent<MsBuildProjectHost>();
                var solutionHost = projectHostContainer.GetComponent<ISolutionHost>();

                var rdSaveProperties = new List<RdSaveProperty>
                {
                    MsBuildModelHelper.CreateSimpleSaveProperty(args.Name, args.Value, null)
                };
                await lifetime.StartMainWrite(() => projectHost.SaveProperties(projectMark, rdSaveProperties));

                componentLifetime.StartMainWrite(() => solutionHost.ReloadProjectAsync(projectMark)).NoAwait();
            });

            model.Project_Delete.SetWithReadLock(solution.Locks, projectModel =>
            {
                var project = GetProject(projectModel);
                if (project is null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Remove(project));
                return Unit.Instance;
            });

            model.Project_get_ConfigurationCount.SetSync(projectModel =>
            {
                var projectMark = GetProject(projectModel)?.GetProjectMark();
                if (projectMark is null) return 0;

                return configurationsStore.GetConfigurationsAndPlatforms(projectMark).Count;
            });

            model.Project_get_ConfigurationNames.SetSync(projectModel =>
            {
                var projectMark = GetProject(projectModel)?.GetProjectMark();
                if (projectMark is null) return [];

                return configurationsStore.GetConfigurationsAndPlatforms(projectMark)
                    .Select(cp => cp.Configuration)
                    .Distinct()
                    .ToList();
            });

            model.Project_get_PlatformNames.SetSync(projectModel =>
            {
                var projectMark = GetProject(projectModel)?.GetProjectMark();
                if (projectMark is null) return [];

                return configurationsStore.GetConfigurationsAndPlatforms(projectMark)
                    .Select(cp => cp.Platform)
                    .Distinct()
                    .ToList();
            });
        }

        [CanBeNull]
        private IProject GetProject(Rider.Model.ProjectModel rdModel) => host.GetItemById<IProject>(rdModel.Id);

        private static string CalculateProjectUniqueName([NotNull] IProject project)
        {
            var solutionDirPath = project.GetSolution().SolutionDirectory;
            var projectFilePath = project.ProjectFileLocation;

            return projectFilePath.MakeRelativeTo(solutionDirPath).FullPath;
        }
    }
}
