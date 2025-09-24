using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.Application.Parts;
using JetBrains.Build.Helpers.Msbuild;
using JetBrains.DocumentManagers.Transactions;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.MSBuild;
using JetBrains.ProjectModel.Properties;
using JetBrains.ReSharper.Resources.Shell;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel;

[ShellComponent(Instantiation.DemandAnyThreadSafe)]
public class EnvDTEProjectPropertiesManager : IProjectPropertiesRequest
{
    // Visual Studio property names
    private const string FullPathProperty = "FullPath";
    private const string FriendlyTargetFrameworkNameProperty = "FriendlyTargetFramework";
    private const string OutputFileNameProperty = "OutputFileName";

    // MsBuild property names
    private const string TargetFileNameProperty = "TargetFileName";

    // Direct mapping between VS property names and MSBuild property names
    private static readonly ReadOnlyDictionary<string, string> Mappings = new(new Dictionary<string, string>()
    {
        { FriendlyTargetFrameworkNameProperty, MSBuildProjectUtil.TargetFrameworkProperty },
        { FullPathProperty, MsbuildFile.Properties.MSBuildProjectDirectory },
        { OutputFileNameProperty, TargetFileNameProperty },
        { MSBuildProjectUtil.RootNamespaceProperty, MSBuildProjectUtil.RootNamespaceProperty },
        { MSBuildProjectUtil.AssemblyNameProperty, MSBuildProjectUtil.AssemblyNameProperty },
        { MSBuildProjectUtil.TargetFrameworkMonikerProperty, MSBuildProjectUtil.TargetFrameworkMonikerProperty },
    });

    public IEnumerable<string> RequestedProperties =>
    [
        MSBuildProjectUtil.RootNamespaceProperty,
        MSBuildProjectUtil.AssemblyNameProperty,
        MSBuildProjectUtil.TargetNameProperty,
        MSBuildProjectUtil.TargetExtProperty,
        MSBuildProjectUtil.TargetFrameworkProperty,
        MSBuildProjectUtil.TargetFrameworkMonikerProperty,
        MsbuildFile.Properties.MSBuildProjectDirectory,
        TargetFileNameProperty
    ];

    [CanBeNull]
    public static async Task<string> GetPropertyValueAsync(
        Lifetime lifetime,
        [NotNull] IProject project,
        [NotNull] string vsPropertyName)
    {
        if (!TryMapPropertyName(vsPropertyName, out var propertyName))
            throw new KeyNotFoundException($"Property '{vsPropertyName}' not found");

        string result = null;
        await lifetime.StartMainWrite(() =>
            project.GetSolution().GetComponent<IProjectModelEditor>().EditProjectMsBuildProperties(project, null,
                editor => { result = editor.TryGetValue(propertyName); }));

        return result;
    }

    public static async Task SetPropertyValueAsync(
        Lifetime lifetime,
        [NotNull] IProject project,
        [NotNull] string vsPropertyName,
        [CanBeNull] string propertyValue)
    {
        if (!TryMapPropertyName(vsPropertyName, out var propertyName))
            throw new KeyNotFoundException($"Property '{vsPropertyName}' not found");

        await lifetime.StartMainWrite(() =>
            project.GetSolution().GetComponent<IProjectModelEditor>().EditProjectMsBuildProperties(project, null,
                editor => { editor.SetProperty(propertyName, propertyValue ?? string.Empty); }));
    }

    public static bool IsValidProperty([NotNull] string vsPropertyName) =>
        TryMapPropertyName(vsPropertyName, out _);

    // TODO: Add additional logic
    private static bool TryMapPropertyName([NotNull] string vsPropertyName, out string msBuildPropertyName) =>
        Mappings.TryGetValue(vsPropertyName, out msBuildPropertyName);
}
