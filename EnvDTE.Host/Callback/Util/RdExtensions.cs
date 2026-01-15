using System;
using JetBrains.Annotations;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Features.SolutionBuilders;
using JetBrains.ProjectModel.Properties;
using JetBrains.ProjectModel.SolutionStructure.SolutionConfigurations;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Util;

public static class RdExtensions
{
    public static LanguageModel ToRdLanguageModel(this ProjectLanguage language)
    {
        if (language == ProjectLanguage.CSHARP) return LanguageModel.CSharp;
        if (language == ProjectLanguage.VBASIC) return LanguageModel.VB;
        if (language == ProjectLanguage.JAVASCRIPT) return LanguageModel.JS;
        if (language == ProjectLanguage.JSON) return LanguageModel.JSON;
        if (language == ProjectLanguage.JSX) return LanguageModel.JSX;
        if (language == ProjectLanguage.CPP) return LanguageModel.Cpp;
        return LanguageModel.Unknown;
    }

    public static IBuildSessionTarget FromRdBuildSessionTarget(this RdBuildSessionTarget target) => target switch
    {
        RdBuildSessionTarget.Build => BuildSessionTarget.Build,
        RdBuildSessionTarget.Clean => BuildSessionTarget.Clean,
        _ => throw new ArgumentOutOfRangeException(nameof(target))
    };

    public static RdSolutionConfiguration ToRdSolutionConfiguration(this SolutionConfigurationAndPlatform config) =>
        new(config.Configuration, config.Platform);

    public static SolutionConfigurationAndPlatform FromRdSolutionConfiguration(this RdSolutionConfiguration config) =>
        new(config.Name, config.Platform);

    [CanBeNull]
    public static Solution_find_ProjectItemResponse ToRdFindProjectItemResponse(
        this IProjectItem projectItem,
        IProject containingProject,
        ProjectModelViewHost viewHost)
    {
        var id = viewHost.GetIdByItem(projectItem);
        if (id == 0) return null;

        return new Solution_find_ProjectItemResponse(
            new ProjectItemModel(id),
            new ProjectItemModel(viewHost.GetIdByItem(containingProject)));
    }
}
