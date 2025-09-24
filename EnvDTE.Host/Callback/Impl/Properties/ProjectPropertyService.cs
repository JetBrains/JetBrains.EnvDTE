using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Build.Helpers.Msbuild;
using JetBrains.DocumentManagers.Transactions;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.MSBuild;
using JetBrains.ReSharper.Resources.Shell;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Properties;

public class ProjectPropertyService : IPropertyService<IProject>
{
    // Visual Studio property names
    private const string FullPathProperty = "FullPath";
    private const string FriendlyTargetFrameworkNameProperty = "FriendlyTargetFramework";
    private const string OutputFileNameProperty = "OutputFileName";

    // MsBuild property names
    private const string TargetFileNameProperty = "TargetFileName";

    // Direct mapping between VS property names and MSBuild property names
    private static readonly ReadOnlyDictionary<string, string> VsPropertyNameMap = new(new Dictionary<string, string>()
    {
        { FriendlyTargetFrameworkNameProperty, MSBuildProjectUtil.TargetFrameworkProperty },
        { FullPathProperty, MsbuildFile.Properties.MSBuildProjectDirectory },
        { OutputFileNameProperty, TargetFileNameProperty },
        { MSBuildProjectUtil.RootNamespaceProperty, MSBuildProjectUtil.RootNamespaceProperty },
        { MSBuildProjectUtil.AssemblyNameProperty, MSBuildProjectUtil.AssemblyNameProperty },
        { MSBuildProjectUtil.TargetFrameworkMonikerProperty, MSBuildProjectUtil.TargetFrameworkMonikerProperty },
    });

    public async Task<string> GetPropertyAsync(Lifetime lifetime, IProject project, string vsPropertyName)
    {
        if (!TryMapPropertyName(vsPropertyName, out var propertyName))
            throw new PropertyNotFoundException(vsPropertyName);

        string result = null;
        await lifetime.StartMainWrite(() =>
            project.GetSolution().GetComponent<IProjectModelEditor>().EditProjectMsBuildProperties(project, null,
                editor => { result = editor.TryGetValue(propertyName); }));

        return result;
    }

    public async Task SetPropertyAsync(Lifetime lifetime, IProject project, string vsPropertyName, string propertyValue)
    {
        if (!TryMapPropertyName(vsPropertyName, out var propertyName))
            throw new PropertyNotFoundException(vsPropertyName);

        await lifetime.StartMainWrite(() =>
            project.GetSolution().GetComponent<IProjectModelEditor>().EditProjectMsBuildProperties(project, null,
                editor => { editor.SetProperty(propertyName, propertyValue ?? string.Empty); }));
    }

    public bool IsValidProperty(string vsPropertyName) =>
        TryMapPropertyName(vsPropertyName, out _);

    // TODO: Add additional logic
    private static bool TryMapPropertyName([NotNull] string vsPropertyName, out string msBuildPropertyName) =>
        VsPropertyNameMap.TryGetValue(vsPropertyName, out msBuildPropertyName);
}
