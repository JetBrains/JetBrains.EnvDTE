using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.Components;
using JetBrains.Application.Parts;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.Platform.MsBuildHost.Models;
using JetBrains.Platform.MsBuildHost.Utils;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost.Impl;
using JetBrains.ProjectModel.ProjectsHost.MsBuild;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost;
using JetBrains.ProjectModel.Properties;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.RdBackend.Common.Features.ProjectModel.View.EditProperties.Solutions;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Threading;
using JetBrains.Util;
using Key = JetBrains.Util.Key;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl
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
        private const string PlatformProperty = "Platform";
        private const string SolutionFolderProjectGuid = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
        private readonly Key _uniqueNameKey = new("EnvDTE.UniqueName");

        public void RegisterCallbacks(DteProtocolModel model)
        {
            model.Project_get_Name.SetWithProjectSync(host, (_, project) => project.Name);

            model.Project_set_Name.SetWithProjectVoidAsync(host, (lifetime, req, project) =>
                lifetime.StartReadActionAsync(() =>
                    solution.InvokeUnderTransaction(cookie => cookie.Rename(project, req.NewName))));

            model.Project_get_FileName.SetWithProjectSync(host, (_, project) => project.ProjectFileLocation.FullPath);

            model.Project_get_UniqueName.SetWithProjectAsync(host, async (lifetime, _, project) =>
            {
                var uniqueName = await lifetime.StartReadActionAsync(() => project.GetProperty(_uniqueNameKey) as string);
                if (uniqueName is not null) return uniqueName;

                uniqueName = CalculateProjectUniqueName(project);
                // Save the unique name to the project properties so we don't have to calculate it every time
                await lifetime.StartMainWrite(() => project.SetProperty(_uniqueNameKey, uniqueName));
                return uniqueName;
            });

            model.Project_get_Kind.SetWithProjectSync(host, (_, project) =>
            {
                if (project.ProjectProperties.ProjectKind == ProjectKind.SOLUTION_FOLDER) return SolutionFolderProjectGuid;

                var guid = project.ProjectProperties.ProjectTypeGuids.FirstOrDefault();
                return guid.ToString("B").ToUpperInvariant();
            });

            model.Project_get_Language.SetWithProjectSync(host, (_, project) =>
                project.ProjectProperties.DefaultLanguage.ToRdLanguageModel());

            model.Project_get_Property.SetWithProjectAsync(host, async (lifetime, req, project) =>
                await lifetime.StartReadActionAsync(() =>
                    project.GetRequestedProjectProperty(project.GetCurrentTargetFrameworkId(), req.Name)));

            model.Project_set_Property.SetWithProjectMarkVoidAsync(host, async (lifetime, args, mark) =>
            {
                logger.Assert(!mark.IsVCXProject(), "Properties of C++ projects cannot be changed this way");

                var projectHostContainer = solution.ProjectsHostContainer();
                var projectHost = projectHostContainer.GetComponent<MsBuildProjectHost>();
                var solutionHost = projectHostContainer.GetComponent<ISolutionHost>();

                var rdSaveProperties = new List<RdSaveProperty>
                {
                    MsBuildModelHelper.CreateSimpleSaveProperty(args.Name, args.Value, null)
                };
                await lifetime.StartMainWrite(() => projectHost.SaveProperties(mark, rdSaveProperties));

                componentLifetime.StartMainWrite(() => solutionHost.ReloadProjectAsync(mark)).NoAwait();
            });

            model.Project_Delete.SetWithProjectVoidAsync(host, (lifetime, _, project) =>
                lifetime.StartReadActionAsync(() => solution.InvokeUnderTransaction(cookie => cookie.Remove(project))));

            model.Project_get_ConfigurationCount.SetWithProjectMarkSync(host, (_, mark) =>
                configurationsStore.GetConfigurationsAndPlatforms(mark).Count);

            model.Project_get_ConfigurationNames.SetWithProjectMarkSync(host, (_, mark) =>
                configurationsStore.GetConfigurationsAndPlatforms(mark)
                    .Select(cp => cp.Configuration)
                    .Distinct()
                    .ToList());

            model.Project_get_PlatformNames.SetWithProjectMarkSync(host, (_, mark) =>
                configurationsStore.GetConfigurationsAndPlatforms(mark)
                    .Select(cp => cp.Platform)
                    .Distinct()
                    .ToList());

            model.Project_get_IsBuildable.SetWithProjectSync(host, (_, project) =>
                project.ProjectProperties.BuildSettings?.IsBuildable ?? false);

            model.Project_get_IsDeployable.SetWithProjectSync(host, (_, project) =>
                project.ProjectProperties.BuildSettings?.IsDeployable ?? false);

            model.Project_get_ActiveConfigName.SetWithProjectSync(host, (_, project) =>
                project.ProjectProperties.TryGetConfiguration<IProjectConfiguration>(
                    project.GetCurrentTargetFrameworkId())?.Name);

            model.Project_get_ActiveConfigPlatformName.SetWithProjectSync(host, (_, project) =>
            {
                var config = project.ProjectProperties.TryGetConfiguration<IProjectConfiguration>(
                    project.GetCurrentTargetFrameworkId());

                return config?.PropertiesCollection.TryGetValue(PlatformProperty, out var platform) == true
                    ? platform
                    : null;
            });
        }

        private static string CalculateProjectUniqueName([NotNull] IProject project)
        {
            var solutionDirPath = project.GetSolution().SolutionDirectory;
            var projectFilePath = project.ProjectFileLocation;

            return projectFilePath.MakeRelativeTo(solutionDirPath).FullPath;
        }
    }
}
