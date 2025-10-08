using System;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Util;

public static class RdExtensions
{
    public static string FromRdItemKindModel(this ProjectItemKindModel model) => model switch
    {
        ProjectItemKindModel.PhysicalFile => Constants.vsProjectItemKindPhysicalFile,
        ProjectItemKindModel.PhysicalFolder => Constants.vsProjectItemKindPhysicalFolder,
        ProjectItemKindModel.Project => Constants.vsProjectItemKindSubProject,
        ProjectItemKindModel.VirtualDirectory => Constants.vsProjectItemKindVirtualFolder,
        ProjectItemKindModel.Unknown => Constants.vsProjectItemKindUnknown,
        _ => throw new ArgumentException($"Invalid project item kind: {model}")
    };

    public static ProjectItemKindModel ToRdItemKindModel([NotNull] this string kind) => kind switch
    {
        Constants.vsProjectItemKindPhysicalFile => ProjectItemKindModel.PhysicalFile,
        Constants.vsProjectItemKindPhysicalFolder => ProjectItemKindModel.PhysicalFolder,
        Constants.vsProjectItemKindSubProject => ProjectItemKindModel.Project,
        Constants.vsProjectItemKindVirtualFolder => ProjectItemKindModel.VirtualDirectory,
        Constants.vsProjectItemKindUnknown => ProjectItemKindModel.Unknown,
        _ => throw new ArgumentException($"Invalid project item kind: {kind}")
    };

    [CanBeNull]
    public static string FromRdLanguageModel(this LanguageModel model) => model switch
    {
        LanguageModel.CSharp => CodeModelLanguageConstants.vsCMLanguageCSharp,
        LanguageModel.VB => CodeModelLanguageConstants.vsCMLanguageVB,
        _ => null
    };

    public static bool IsSupportedLanguage(this LanguageModel language) => language == LanguageModel.CSharp;

    public static vsBuildState FromRdBuildState(this RdBuildState buildState) => buildState switch
    {
        RdBuildState.Done => vsBuildState.vsBuildStateDone,
        RdBuildState.InProgress => vsBuildState.vsBuildStateInProgress,
        RdBuildState.NotStarted => vsBuildState.vsBuildStateNotStarted,
        _ => throw new ArgumentException($"Invalid build state: {buildState}")
    };
}
