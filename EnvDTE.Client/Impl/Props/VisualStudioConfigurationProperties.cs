using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Props.PropertyInfo;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Props;

internal static class VisualStudioConfigurationProperties
{
    // There are two FSharp specific properties mentioned in the files, but they are not present in the actual implementation

    // .NET Framework projects have two additional properties: 'PreferNativeArm64' and 'AuthenticationMode'
    internal static readonly IReadOnlyDictionary<string, StringPropertyInfo> CSharpMapSpecificMap =
        new Dictionary<string, StringPropertyInfo>
        {
            // Treated as a string property, even though it should be an enum
            ["ErrorReport"] = new ("ErrorReport", "ErrorReport", false),
        };

    // '__id', 'ExtenderCATID' and 'ExtenderNames' are not included
    internal static readonly IReadOnlyDictionary<string, StringPropertyInfo> Map =
        new Dictionary<string, StringPropertyInfo>
        {
            ["LanguageVersion"] = new ("LanguageVersion", "LangVersion", false),
            ["CodeAnalysisRuleSet"] = new("CodeAnalysisRuleSet", "CodeAnalysisRuleSet", false),
            ["OutputPath"] = new("OutputPath", "OutputPath", false),
            // Treated as a string property, even though it should be an enum
            ["PlatformTarget"] = new ("PlatformTarget", "PlatformTarget", false),
            ["IntermediatePath"] = new("IntermediatePath", "IntermediateOutputPath", false),
            ["RunCodeAnalysis"] = new BoolPropertyInfo("RunCodeAnalysis", "RunCodeAnalysis", false),
            ["DebugSymbols"] = new("DebugSymbols", "DebugSymbols", false),
            ["DefineDebug"] = new BoolPropertyInfo("DefineDebug", "DefineDebug", false),
            ["DefineTrace"] = new BoolPropertyInfo("DefineTrace", "DefineTrace", false),
            ["DefineConstants"] = new("DefineConstants", "DefineConstants", false),
            ["RemoveIntegerChecks"] = new BoolPropertyInfo("RemoveIntegerChecks", "RemoveIntegerChecks", false),
            ["BaseAddress"] = new("BaseAddress", "BaseAddress", false),
            ["AllowUnsafeBlocks"] = new BoolPropertyInfo("AllowUnsafeBlocks", "AllowUnsafeBlocks", false),
            ["CheckForOverflowUnderflow"] = new BoolPropertyInfo("CheckForOverflowUnderflow", "CheckForOverflowUnderflow", false),
            ["DocumentationFile"] = new("DocumentationFile", "DocumentationFile", false),
            ["Optimize"] = new BoolPropertyInfo("Optimize", "Optimize", false),
            ["IncrementalBuild"] = new BoolPropertyInfo("IncrementalBuild", "IncrementalBuild", false),
            ["StartProgram"] = new ("StartProgram", "StartProgram", false),
            ["StartWorkingDirectory"] = new ("StartWorkingDirectory", "StartWorkingDirectory", false),
            ["StartURL"] = new ("StartURL", "StartURL", false),
            ["StartPage"] = new ("StartPage", "StartPage", false),
            ["StartArguments"] = new ("StartArguments", "StartArguments", false),
            ["StartWithIE"] = new BoolPropertyInfo("StartWithIE", "StartWithIE", false),
            ["EnableASPDebugging"] = new BoolPropertyInfo("EnableASPDebugging", "EnableASPDebugging", false),
            ["EnableASPXDebugging"] = new BoolPropertyInfo("EnableASPXDebugging", "EnableASPXDebugging", false),
            ["EnableUnmanagedDebugging"] = new BoolPropertyInfo("EnableUnmanagedDebugging", "EnableUnmanagedDebugging", false),
            ["StartAction"] = new EnumPropertyInfo("StartAction", "StartAction", false, new ReadOnlyIndexedCanonicalSet<string>(["Project", "Program", "URL", "None"], StringComparer.OrdinalIgnoreCase)),
            // TODO: Implement value provider, see: https://github.com/dotnet/project-system/blob/c616b06472c97e5dbb54f7a92076b69df69d0f76/src/Microsoft.VisualStudio.ProjectSystem.Managed.VS/ProjectSystem/VS/Properties/VisualBasic/WarningLevelEnumProvider.cs
            ["WarningLevel"] = new DynamicEnumPropertyInfo("WarningLevel", "WarningLevel", false),
            ["TreatWarningsAsErrors"] = new BoolPropertyInfo("TreatWarningsAsErrors", "TreatWarningsAsErrors", false),
            ["EnableSQLServerDebugging"] = new BoolPropertyInfo("EnableSQLServerDebugging", "EnableSQLServerDebugging", false),
            // Treated as an Uint32 property, even though it should be an enum
            ["FileAlignment"] = new UIntPropertyInfo("FileAlignment", "FileAlignment", false),
            ["RegisterForComInterop"] = new BoolPropertyInfo("RegisterForComInterop", "RegisterForComInterop", false),
            ["ConfigurationOverrideFile"] = new ("ConfigurationOverrideFile", "ConfigurationOverrideFile", false),
            ["RemoteDebugEnabled"] = new BoolPropertyInfo("RemoteDebugEnabled", "RemoteDebugEnabled", false),
            ["RemoteDebugMachine"] = new ("RemoteDebugMachine", "RemoteDebugMachine", false),
            ["NoWarn"] = new("NoWarn", "NoWarn", false),
            ["NoStdLib"] = new BoolPropertyInfo("NoStdLib", "NoStdLib", false),
            // Treated as a string property, even though it should be an enum
            ["DebugInfo"] = new ("DebugInfo", "DebugType", false),
            ["TreatSpecificWarningsAsErrors"] = new("TreatSpecificWarningsAsErrors", "WarningsAsErrors", false),
            ["CodeAnalysisLogFile"] = new("CodeAnalysisLogFile", "CodeAnalysisLogFile", false),
            ["CodeAnalysisRuleAssemblies"] = new("CodeAnalysisRuleAssemblies", "CodeAnalysisRuleAssemblies", false),
            ["CodeAnalysisInputAssembly"] = new("CodeAnalysisInputAssembly", "CodeAnalysisInputAssembly", false),
            ["CodeAnalysisRules"] = new("CodeAnalysisRules", "CodeAnalysisRules", false),
            ["CodeAnalysisSpellCheckLanguages"] = new("CodeAnalysisSpellCheckLanguages", "CodeAnalysisSpellCheckLanguages", false),
            ["CodeAnalysisUseTypeNameInSuppression"] = new BoolPropertyInfo("CodeAnalysisUseTypeNameInSuppression", "CodeAnalysisUseTypeNameInSuppression", false),
            ["CodeAnalysisModuleSuppressionsFile"] = new("CodeAnalysisModuleSuppressionsFile", "CodeAnalysisModuleSuppressionsFile", false),
            ["UseVSHostingProcess"] = new BoolPropertyInfo("UseVSHostingProcess", "UseVSHostingProcess", false),
            ["GenerateSerializationAssemblies"] = new EnumPropertyInfo("GenerateSerializationAssemblies", "GenerateSerializationAssemblies", false, new ReadOnlyIndexedCanonicalSet<string>(["Auto", "On", "Off"], StringComparer.OrdinalIgnoreCase)),
            ["CodeAnalysisIgnoreGeneratedCode"] = new BoolPropertyInfo("CodeAnalysisIgnoreGeneratedCode", "CodeAnalysisIgnoreGeneratedCode", false),
            ["CodeAnalysisOverrideRuleVisibilities"] = new BoolPropertyInfo("CodeAnalysisOverrideRuleVisibilities", "CodeAnalysisOverrideRuleVisibilities", false),
            ["CodeAnalysisDictionaries"] = new("CodeAnalysisDictionaries", "CodeAnalysisDictionaries", false),
            ["CodeAnalysisCulture"] = new("CodeAnalysisCulture", "CodeAnalysisCulture", false),
            ["CodeAnalysisRuleSetDirectories"] = new("CodeAnalysisRuleSetDirectories", "CodeAnalysisRuleSetDirectories", false),
            ["CodeAnalysisIgnoreBuiltInRuleSets"] = new BoolPropertyInfo("CodeAnalysisIgnoreBuiltInRuleSets", "CodeAnalysisIgnoreBuiltInRuleSets", false),
            ["CodeAnalysisRuleDirectories"] = new("CodeAnalysisRuleDirectories", "CodeAnalysisRuleDirectories", false),
            ["CodeAnalysisIgnoreBuiltInRules"] = new BoolPropertyInfo("CodeAnalysisIgnoreBuiltInRules", "CodeAnalysisIgnoreBuiltInRules", false),
            ["CodeAnalysisFailOnMissingRules"] = new BoolPropertyInfo("CodeAnalysisFailOnMissingRules", "CodeAnalysisFailOnMissingRules", false),
            ["Prefer32Bit"] = new BoolPropertyInfo("Prefer32Bit", "Prefer32Bit", false),
        };

    internal static IReadOnlyDictionary<string, StringPropertyInfo> GetLanguageSpecificMap(LanguageModel languageModel) =>
        languageModel switch
        {
            LanguageModel.CSharp => CSharpMapSpecificMap,
            _ => new Dictionary<string, StringPropertyInfo>()
        };
}
