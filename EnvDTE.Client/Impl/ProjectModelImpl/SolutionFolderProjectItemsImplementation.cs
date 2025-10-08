using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl;

public class SolutionFolderProjectItemsImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] ProjectImplementation containingProject,
    [NotNull] object parent,
    [NotNull] ProjectItemModel parentItemModel)
    : ProjectItemsImplementation(dte, containingProject, parent, parentItemModel)
{
    public override string Kind => Constants.vsProjectItemsKindSolutionItems;

    protected override ProjectItemImplementation CreateProjectItem(ProjectItemModel projectItemModel) =>
        new SolutionFolderProjectItemImplementation(DteImplementation, projectItemModel, ContainingProjectImplementation);
}
