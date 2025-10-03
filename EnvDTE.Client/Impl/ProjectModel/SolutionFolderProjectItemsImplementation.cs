using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel;

public class SolutionFolderProjectItemsImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] List<ProjectItemModel> projectItemModels,
    [NotNull] ProjectImplementation containingProject,
    [CanBeNull] ProjectItemImplementation parent = null)
    : ProjectItemsImplementation(dte, projectItemModels, containingProject, parent)
{
    public override string Kind => Constants.vsProjectItemsKindSolutionItems;

    protected override ProjectItemImplementation CreateProjectItem(ProjectItemModel projectItemModel) =>
        new SolutionFolderProjectItemImplementation(DteImplementation, projectItemModel, ContainingProjectImplementation, ParentProjectItemImplementation);
}
