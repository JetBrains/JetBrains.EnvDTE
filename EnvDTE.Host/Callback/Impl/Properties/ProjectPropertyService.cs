using System;
using System.Threading.Tasks;
using JetBrains.Application.Components;
using JetBrains.Application.Parts;
using JetBrains.DocumentManagers.Transactions;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Threading;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Properties;

[SolutionComponent(Instantiation.DemandAnyThreadSafe)]
public class ProjectPropertyService(
    Lifetime serviceLifetime,
    ILogger logger,
    ISolution solution,
    ISimpleLazy<IProjectModelEditor> projectModelEditor)
    : IPropertyService<IProject>
{
    // Right now you can only statically request properties to be loaded into configuration through the `JetBrains.ProjectModel.Properties.IProjectPropertiesRequest`
    // A way to make this more efficient would be to make properties in `JetBrains.ProjectModel.Properties.ProjectPropertiesRequests`
    // modifiable, so that we can dynamically request new properties after the user has accessed them (and they were not inside the configuration)
    // This way we would "cache" them inside configurations in case the user read them again

    // TODO It might be necessary to reload the project here, other parts of the system might change properties without reloading the active configurations
    public async Task<string> GetPropertyAsync(Lifetime lifetime, IProject project, string name)
    {
        // Try to get the property from the active configurations and only fall back to reading the project properties if necessary
        // We first try this to avoid using the project model editor because it will reload the project via the MsBuild task
        foreach (var configuration in project.ProjectProperties.ActiveConfigurations.Configurations)
        {
            if (configuration.PropertiesCollection.TryGetValue(name, out var value)) return value;
        }

        var buildSettings = project.ProjectProperties.BuildSettings;
        var configurationName =
            buildSettings is not null ? $"{buildSettings.Configuration}|{buildSettings.PlatformTarget}" : null;

        string result = null;
        try
        {
            await lifetime.StartMainWrite(() => projectModelEditor.Value.EditProjectMsBuildProperties(project, configurationName,
                editor => result = editor.TryGetValue(name)));
        }
        catch (Exception e)
        {
            logger.Error(e, $"Failed to get property for project: '{project.Name}'");
        }

        return result;
    }

    public async Task SetPropertyAsync(Lifetime lifetime, IProject project, string name, string value)
    {
        var isSuccess = false;
        try
        {
            await lifetime.StartMainWrite(() => projectModelEditor.Value.EditProjectMsBuildProperties(project, null,
                editor => isSuccess = editor.SetProperty(name, value ?? string.Empty)));
        }
        catch (Exception e)
        {
            logger.Error(e, $"Failed to set property for project: '{project.Name}'");
        }

        if (!isSuccess) return;

        // If the property is successfully set, we need to reload the project so that the change is applied to the
        // active configurations
        var projectMark = project.GetProjectMark();
        if (projectMark is null)
        {
            logger.Warn($"Failed to reload the project '{project.Name}' becasue the project mark is null");
            return;
        }

        var solutionHost = solution.ProjectsHostContainer().GetComponent<ISolutionHost>();
        // We don't have to wait for the reload to complete, but that also means that we need to use the service
        // lifetime for the reload, because the passed lifetime will likely be terminated before the reload completes
        serviceLifetime.StartMainWrite(() => solutionHost.ReloadProjectSync(projectMark)).NoAwait();
    }
}
