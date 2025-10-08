using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.Application.Parts;
using JetBrains.Build.Helpers.Msbuild;
using JetBrains.ProjectModel.MSBuild;
using JetBrains.ProjectModel.Properties;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl;

[ShellComponent(Instantiation.DemandAnyThreadSafe)]
public class EnvDteCommonProjectPropertiesRequest : IProjectPropertiesRequest
{
    /// <summary>
    /// List of the properties that are required by EFCore tools.
    /// Could be extended in the future with other commonly used properties.
    /// </summary>
    public IEnumerable<string> RequestedProperties => [
        MSBuildProjectUtil.AssemblyNameProperty,
        MSBuildProjectUtil.RootNamespaceProperty,
        MSBuildProjectUtil.TargetFrameworkProperty,
        MSBuildProjectUtil.TargetFrameworkMonikerProperty,
        MsbuildFile.Properties.MSBuildProjectFullPath,
        "TargetFileName",
        MSBuildProjectUtil.IntermediateOutputPathProperty,
        MSBuildProjectUtil.OutputPathProperty,
        MSBuildProjectUtil.PlatformTargetProperty
    ];
}
