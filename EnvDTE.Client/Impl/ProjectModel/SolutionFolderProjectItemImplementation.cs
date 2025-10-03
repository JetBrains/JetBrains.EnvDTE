using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel;

public class SolutionFolderProjectItemImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] ProjectItemModel projectItemModel,
    [NotNull] ProjectImplementation containingProject)
    : ProjectItemImplementation(dte, projectItemModel, containingProject)
{
    [CanBeNull] private ProjectImplementation _subProjectImplementation;

    private ProjectImplementation SubProjectImplementation
    {
        get
        {
            _subProjectImplementation ??= new(
                DteImplementation, new Rider.Model.ProjectModel(ProjectItemModel.Id), this);
            return _subProjectImplementation;
        }
    }

    public override string Kind => Constants.vsProjectItemKindSolutionItems;

    public override object Object => SubProjectImplementation;

    public override Project SubProject => SubProjectImplementation;

    // ReSharper disable once AssignNullToNotNullAttribute
    public override ProjectItems ProjectItems => null;
}
