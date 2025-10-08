using System;
using JetBrains.ProjectModel.Features.SolutionBuilders;
using JetBrains.ProjectModel.Properties;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Util;

public static class RdExtensions
{
    public static LanguageModel ToRdLanguageModel(this ProjectLanguage language)
    {
        if (string.Equals(language.PresentableName, ProjectLanguage.CSHARP.PresentableName, StringComparison.Ordinal))
            return LanguageModel.CSharp;
        if (string.Equals(language.PresentableName, ProjectLanguage.VBASIC.PresentableName, StringComparison.Ordinal))
            return LanguageModel.VB;
        if (string.Equals(language.PresentableName, ProjectLanguage.JAVASCRIPT.PresentableName, StringComparison.Ordinal))
            return LanguageModel.JS;
        if (string.Equals(language.PresentableName, ProjectLanguage.JSON.PresentableName, StringComparison.Ordinal))
            return LanguageModel.JSON;
        if (string.Equals(language.PresentableName, ProjectLanguage.JSX.PresentableName, StringComparison.Ordinal))
            return LanguageModel.JSX;
        return string.Equals(language.PresentableName, ProjectLanguage.CPP.PresentableName, StringComparison.Ordinal)
            ? LanguageModel.Cpp
            : LanguageModel.Unknown;
    }

    public static IBuildSessionTarget FromRdBuildSessionTarget(this RdBuildSessionTarget target) => target switch
    {
        RdBuildSessionTarget.Build => BuildSessionTarget.Build,
        RdBuildSessionTarget.Clean => BuildSessionTarget.Clean,
        _ => throw new ArgumentOutOfRangeException(nameof(target))
    };
}
