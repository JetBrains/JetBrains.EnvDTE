using System;
using System.Collections.Generic;
using JetBrains.EnvDTE.Client.Impl.PropertyImpl.PropertyInfo;

namespace JetBrains.EnvDTE.Client.Impl.PropertyImpl;

// TODO: Improve support for C++ project properties
internal static class VisualStudioProjectProperties
{
    internal static readonly IReadOnlyDictionary<string, StringPropertyInfo> Map =
        new Dictionary<string, StringPropertyInfo>
        {
            ["ApplicationIcon"] = new("ApplicationIcon", "ApplicationIcon", false),
            ["ApplicationManifest"] = new("ApplicationManifest", "ApplicationManifest", false),
            ["AssemblyName"] = new("AssemblyName", "AssemblyName", false),
            ["AssemblyOriginatorKeyFile"] = new("AssemblyOriginatorKeyFile", "AssemblyOriginatorKeyFile", false),
            ["AssemblyVersion"] = new("AssemblyVersion", "AssemblyVersion", false),
            ["Authors"] = new("Authors", "Authors", false),
            ["AutoGenerateBindingRedirects"] = new BoolPropertyInfo("AutoGenerateBindingRedirects", "AutoGenerateBindingRedirects", false),
            ["AuthenticationMode"] = new EnumPropertyInfo("AuthenticationMode", "AuthenticationMode", false, new (["None", "Windows"], StringComparer.OrdinalIgnoreCase)),
            ["CanUseTargetFSharpCoreVersion"] = new BoolPropertyInfo("CanUseTargetFSharpCoreVersion", "CanUseTargetFSharpCoreVersion", false),
            ["Company"] = new("Company", "Company", false),
            ["Copyright"] = new("Copyright", "Copyright", false),
            ["DefaultNamespace"] = new("DefaultNamespace", "RootNamespace", false),
            ["DelaySign"] = new BoolPropertyInfo("DelaySign", "DelaySign", false),
            ["Description"] = new("Description", "Description", false),
            ["FileName"] = new("FileName", "MSBuildProjectFile", true),
            ["FileVersion"] = new("FileVersion", "FileVersion", false),
            ["FullPath"] = new("FullPath", "MSBuildProjectDirectory", true),
            ["FullProjectFileName"] = new("FullProjectFileName", "MSBuildProjectFullPath", true),
            ["GenerateAssemblyInfo"] = new BoolPropertyInfo("GenerateAssemblyInfo", "GenerateAssemblyInfo", false),
            ["GeneratePackageOnBuild"] = new BoolPropertyInfo("GeneratePackageOnBuild", "GeneratePackageOnBuild", false),
            ["LocalPath"] = new("LocalPath", "MSBuildProjectDirectory", true),
            ["MyType"] = new("MyType", "MyType", false),
            ["Name"] = new("Name", "Name", false),
            ["NeutralLanguage"] = new("NeutralLanguage", "NeutralLanguage", false),
            ["OutputFileName"] = new("OutputFileName", "TargetFileName", true),
            ["OutputName"] = new("OutputName", "OutputName", false),
            ["OutputType"] = new MappedPropertyInfo<int>("OutputType", "OutputType", false, [(0, "WinExe"), (1, "Exe"), (2, "Library")]),
            ["OutputTypeEx"] = new MappedPropertyInfo<int>("OutputTypeEx", "OutputType", false, [(0, "WinExe"), (1, "Exe"), (2, "Library"), (3, "WinMDObj"), (4, "AppContainerExe")]),
            ["PackageIconUrl"] = new("PackageIconUrl", "PackageIconUrl", false),
            ["PackageIcon"] = new("PackageIcon", "PackageIcon", false),
            ["PackageId"] = new("PackageId", "PackageId", false),
            ["PackageLicenseExpression"] = new("PackageLicenseExpression", "PackageLicenseExpression", false),
            ["PackageLicenseFile"] = new("PackageLicenseFile", "PackageLicenseFile", false),
            ["PackageLicenseUrl"] = new("PackageLicenseUrl", "PackageLicenseUrl", false),
            ["PackageProjectUrl"] = new("PackageProjectUrl", "PackageProjectUrl", false),
            ["PackageReleaseNotes"] = new("PackageReleaseNotes", "PackageReleaseNotes", false),
            ["PackageRequireLicenseAcceptance"] = new BoolPropertyInfo("PackageRequireLicenseAcceptance", "PackageRequireLicenseAcceptance", false),
            ["PackageTags"] = new("PackageTags", "PackageTags", false),
            ["PostBuildEvent"] = new("PostBuildEvent", "PostBuildEvent", false),
            ["PreBuildEvent"] = new("PreBuildEvent", "PreBuildEvent", false),
            ["Product"] = new("Product", "Product", false),
            ["ReferencePath"] = new("ReferencePath", "ReferencePath", false),
            ["RepositoryType"] = new("RepositoryType", "RepositoryType", false),
            ["RepositoryUrl"] = new("RepositoryUrl", "RepositoryUrl", false),
            ["RootNamespace"] = new("RootNamespace", "RootNamespace", false),
            ["RunPostBuildEvent"] = new EnumPropertyInfo("RunPostBuildEvent", "RunPostBuildEvent", false, new (["Always", "OnBuildSuccess", "OnOutputUpdated"], StringComparer.OrdinalIgnoreCase)),
            ["SignAssembly"] = new BoolPropertyInfo("SignAssembly", "SignAssembly", false),
            ["StartupObject"] = new ("StartupObject", "StartupObject", false),
            ["SupportedTargetFrameworks"] = new ("SupportedTargetFrameworks", "SupportedTargetFrameworks", false),
            // TODO: Figure out how they calculate this property
            ["TargetFramework"] = new ("TargetFramework", "TargetFramework", true),
            ["FriendlyTargetFramework"] = new("FriendlyTargetFramework", "TargetFramework", false),
            ["TargetFrameworkMoniker"] = new("TargetFrameworkMoniker", "TargetFrameworkMoniker", false),
            ["TargetFrameworkMonikers"] = new("TargetFrameworkMonikers", "TargetFrameworkMonikers", true),
            ["TargetFrameworks"] = new("TargetFrameworks", "TargetFrameworks", false),
            ["TargetFSharpCoreVersion"] = new("TargetFSharpCoreVersion", "TargetFSharpCoreVersion", false),
            ["ActiveDebugProfile"] = new("ActiveDebugProfile", "ActiveDebugProfile", false),
            ["URL"] = new("URL", "MSBuildProjectFullPath", true),
            ["Version"] = new("Version", "Version", false),
            ["Win32ResourceFile"] = new("Win32ResourceFile", "Win32Resource", false),
            ["RunAnalyzersDuringBuild"] = new BoolPropertyInfo("RunAnalyzersDuringBuild", "RunAnalyzersDuringBuild", false),
            ["RunAnalyzersDuringLiveAnalysis"] = new BoolPropertyInfo("RunAnalyzersDuringLiveAnalysis", "RunAnalyzersDuringLiveAnalysis", false),
            ["EnableNETAnalyzers"] = new BoolPropertyInfo("EnableNETAnalyzers", "EnableNETAnalyzers", false),
            ["AnalysisLevel"] = new("AnalysisLevel", "AnalysisLevel", false),
            ["EnforceCodeStyleInBuild"] = new BoolPropertyInfo("EnforceCodeStyleInBuild", "EnforceCodeStyleInBuild", false),
        };
}
