using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Properties;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.RdBackend.Common.Features.ProjectModel.View.EditProperties.Solutions;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public class ProjectCallbackProvider(
        Lifetime componentLifetime,
        ISolution solution,
        ProjectModelViewHost host,
        MsBuildProjectsConfigurationsStore configurationsStore)
        : IEnvDteCallbackProvider
    {
        private const string PlatformProperty = "Platform";
        private const string SolutionFolderProjectGuid = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";

        public void RegisterCallbacks(DteProtocolModel model)
        {
            model.Project_get_Name.SetWithProjectSync(host, (_, project) => project.Name);

            model.Project_set_Name.SetWithProjectVoidAsync(host, (lifetime, req, project) =>
                lifetime.StartReadActionAsync(() =>
                    solution.InvokeUnderTransaction(cookie => cookie.Rename(project, req.NewName))));

            model.Project_get_FileName.SetWithProjectSync(host, (_, project) => project.ProjectFileLocation.FullPath);

            model.Project_get_UniqueName.SetWithProjectSync(host, (_, project) => project.GetVSUniqueName(componentLifetime));

            model.Project_get_Kind.SetWithProjectSync(host, (_, project) =>
            {
                if (project.IsSolutionFolder()) return SolutionFolderProjectGuid;

                // Last Guid is always the one we want displayed
                var guid = project.ProjectProperties.ProjectTypeGuids.LastOrDefault();
                return guid.ToString("B").ToUpperInvariant();
            });

            model.Project_get_Language.SetWithProjectSync(host, (_, project) =>
                project.ProjectProperties.DefaultLanguage.ToRdLanguageModel());

            model.Project_get_Property.SetWithProjectAsync(host, (lifetime, req, project) =>
                project.GetPropertyAsync(lifetime, req.Name));

            model.Project_set_Property.SetWithProjectVoidAsync(host, (lifetime, args, project) =>
                project.SetPropertyAsync(lifetime, args.Name, args.Value));

            model.Project_is_CPS.SetWithProjectSync(host, (_, project) => project.IsCPSProject(componentLifetime));

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
    }
}
