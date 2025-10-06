using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.Application.Parts;
using JetBrains.Build.Helpers.Msbuild;
using JetBrains.ProjectModel.MSBuild;
using JetBrains.ProjectModel.Properties;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel;

[ShellComponent(Instantiation.DemandAnyThreadSafe)]
public class EnvDteProjectPropertyRequest : IProjectPropertiesRequest
{
    public IEnumerable<string> RequestedProperties => [
        MSBuildProjectUtil.ApplicationIconProperty,
        MSBuildProjectUtil.AssemblyNameProperty,
        MSBuildProjectUtil.AutoGenerateBindingRedirectsProperty,
        MSBuildProjectUtil.RootNamespaceProperty,
        MSBuildProjectUtil.MyTypeProperty,
        MSBuildProjectUtil.OutputTypeProperty,
        MSBuildProjectUtil.PackageIdProperty,
        MSBuildProjectUtil.StartupObjectProperty,
        MSBuildProjectUtil.TargetFrameworkProperty,
        MSBuildProjectUtil.TargetFrameworkMonikerProperty,
        MSBuildProjectUtil.TargetFrameworksProperty,
        MSBuildProjectUtil.VersionProperty,
        MsbuildFile.Properties.ApplicationManifest,
        MsbuildFile.Properties.AssemblyOriginatorKeyFile,
        MsbuildFile.Properties.DelaySign,
        MsbuildFile.Properties.MSBuildProjectFile,
        MsbuildFile.Properties.MSBuildProjectDirectory,
        MsbuildFile.Properties.MSBuildProjectFullPath,
        MsbuildFile.Properties.GenerateAssemblyInfo,
        MsbuildFile.Properties.PostBuildEvent,
        MsbuildFile.Properties.PreBuildEvent,
        MsbuildFile.Properties.ReferencePath,
        MsbuildFile.Properties.SignAssembly,
        MsbuildFile.Metadatas.AssemblyVersion,
        "Authors",
        "AuthenticationMode",
        "CanUseTargetFSharpCoreVersion",
        "Company",
        "Copyright",
        "Description",
        "FileVersion",
        "GeneratePackageOnBuild",
        "Name",
        "NeutralLanguage",
        "TargetFileName",
        "OutputName",
        "OutputTypeEx",
        "PackageIconUrl",
        "PackageIcon",
        "PackageLicenseExpression",
        "PackageLicenseFile",
        "PackageLicenseUrl",
        "PackageProjectUrl",
        "PackageReleaseNotes",
        "PackageRequireLicenseAcceptance",
        "PackageTags",
        "Product",
        "RepositoryType",
        "RepositoryUrl",
        "RunPostBuildEvent",
        "SupportedTargetFrameworks",
        "TargetFrameworkMonikers",
        "TargetFSharpCoreVersion",
        "ActiveDebugProfile",
        "Win32Resource",
        "RunAnalyzersDuringBuild",
        "RunAnalyzersDuringLiveAnalysis",
        "EnableNETAnalyzers",
        "AnalysisLevel",
        "EnforceCodeStyleInBuild",
        // Configuration properties
        // TODO: Figure out what we are going to do with these
        "IntermediateOutputPath"
    ];
}
