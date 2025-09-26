using System;
using System.Collections.Generic;
using JetBrains.Build.Helpers.Msbuild;
using JetBrains.ProjectModel.MSBuild;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Properties;

public record VisualStudioProperty(string RiderName, bool IsReadOnly);

// Based on https://github.com/dotnet/project-system/blob/9475b6468a9f9b1b627f62d9d9225d23c02e5a49/src/Microsoft.VisualStudio.ProjectSystem.Managed/ProjectSystem/Rules/GeneralBrowseObject.xaml
public static class VisualStudioProjectProperties
{
    public static readonly IReadOnlyDictionary<string, VisualStudioProperty> PropertyMap =
        new Dictionary<string, VisualStudioProperty>(StringComparer.InvariantCultureIgnoreCase)
        {
            {"DefaultNamespace", new (MsbuildFile.Properties.RootNamespace, false)},
            {"FileName", new (MsbuildFile.Properties.MSBuildProjectFile, true)},
            {"FullPath", new (MsbuildFile.Properties.MSBuildProjectDirectory, true)},
            {"FullProjectFileName", new (MsbuildFile.Properties.MSBuildProjectFullPath, true)},
            {"LocalPath", new (MsbuildFile.Properties.MSBuildProjectDirectory, true)},
            {"OutputFileName", new ("TargetFileName", true)},
            {"URL", new (MsbuildFile.Properties.MSBuildProjectFullPath, true)},
            {"FriendlyTargetFramework", new (MsbuildFile.Properties.TargetFramework, false)},
            {"TargetFramework", new (MsbuildFile.Properties.TargetFramework, true)},
            {"TargetFrameworkMoniker", new (MSBuildProjectUtil.TargetFrameworkMonikerProperty, false)},
            {"TargetFrameworkMonikers", new (MsbuildFile.Metadatas.TargetFrameworkMonikers, true)},
            {"TargetFrameworks", new (MsbuildFile.Metadatas.TargetFrameworks, false)},
            {"AssemblyName", new (MsbuildFile.Properties.AssemblyName, false)},
            {"Company", new ("Company", false)},
            {"Product", new ("Product", false)},
            {"Description", new ("Description", false)},
            {"Version", new (MSBuildProjectUtil.VersionProperty, false)},
            {"FileVersion", new ("FileVersion", false)},
            {"AssemblyVersion", new (MsbuildFile.Metadatas.AssemblyVersion, false)},
            {"Copyright", new ("Copyright", false)},
            {"NeutralLanguage", new ("NeutralLanguage", false)},
            {"PostBuildEvent", new (MsbuildFile.Properties.PostBuildEvent, false)},
            {"PreBuildEvent", new (MsbuildFile.Properties.PreBuildEvent, false)},
            {"RunPostBuildEvent", new ("RunPostBuildEvent", false)},
            {"SignAssembly", new (MsbuildFile.Properties.SignAssembly, false)},
            {"AssemblyOriginatorKeyFile", new (MsbuildFile.Properties.AssemblyOriginatorKeyFile, false)},
            {"DelaySign", new (MsbuildFile.Properties.DelaySign, false)},
            {"Win32ResourceFile", new ("Win32Resource", false)},
            {"StartupObject", new (MSBuildProjectUtil.StartupObjectProperty, false)},
            {"ApplicationIcon", new (MSBuildProjectUtil.ApplicationIconProperty, false)},
            {"ApplicationManifest", new (MsbuildFile.Properties.ApplicationManifest, false)},
            {"GeneratePackageOnBuild", new ("GeneratePackageOnBuild", false)},
            {"PackageId", new (MSBuildProjectUtil.PackageIdProperty, false)},
            {"PackageIcon", new ("PackageIcon", false)},
            {"PackageIconUrl", new ("PackageIconUrl", false)},
            {"PackageLicenseExpression", new ("PackageLicenseExpression", false)},
            {"PackageLicenseFile", new ("PackageLicenseFile", false)},
            {"PackageLicenseUrl", new ("PackageLicenseUrl", false)},
            {"PackageProjectUrl", new ("PackageProjectUrl", false)},
            {"PackageReleaseNotes", new ("PackageReleaseNotes", false)},
            {"PackageRequireLicenseAcceptance", new ("PackageRequireLicenseAcceptance", false)},
            {"PackageTags", new ("PackageTags", false)},
            {"RepositoryUrl", new ("RepositoryUrl", false)},
            {"RepositoryType", new ("RepositoryType", false)},
            {"RunAnalyzersDuringBuild", new ("RunAnalyzersDuringBuild", false)},
            {"RunAnalyzersDuringLiveAnalysis", new ("RunAnalyzersDuringLiveAnalysis", false)},
            {"EnableNETAnalyzers", new ("EnableNETAnalyzers", false)},
            {"AnalysisLevel", new ("AnalysisLevel", false)},
            {"EnforceCodeStyleInBuild", new ("EnforceCodeStyleInBuild", false)},
            {"AutoGenerateBindingRedirects", new (MsbuildFile.Properties.AutoGenerateBindingRedirects, false)},
            {"AuthenticationMode", new ("AuthenticationMode", false)},
            {"CanUseTargetFSharpCoreVersion", new ("CanUseTargetFSharpCoreVersion", false)},
            {"GenerateAssemblyInfo", new (MsbuildFile.Properties.GenerateAssemblyInfo, false)},
            {"MyType", new (MSBuildProjectUtil.MyTypeProperty, false)},
            {"Name", new ("Name", false)},
            {"OutputType", new (MsbuildFile.Properties.OutputType, false)},
            {"OutputTypeEx", new ("OutputTypeEx", false)},
            {"ReferencePath", new (MsbuildFile.Properties.ReferencePath, false)},
            {"RootNamespace", new (MsbuildFile.Properties.RootNamespace, false)},
            {"SupportedTargetFrameworks", new ("SupportedTargetFrameworks", false)},
            {"TargetFSharpCoreVersion", new ("TargetFSharpCoreVersion", false)},
            {"ActiveDebugProfile", new ("ActiveDebugProfile", false)},
            {"Authors", new ("Authors", false)},
        };
}
