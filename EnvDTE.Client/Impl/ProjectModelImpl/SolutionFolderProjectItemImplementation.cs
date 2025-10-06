using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl;

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
            if (_subProjectImplementation is null)
            {
                // See documentation
                _subProjectImplementation =
                    (dte.DteProtocolModel.ProjectItem_get_Kind.Sync(projectItemModel) == ProjectItemKindModel.PhysicalFile)
                    ? null
                    : new(DteImplementation, new ProjectModel(ProjectItemModel.Id), this);
            }
            return _subProjectImplementation;
        }
    }

    public override string Kind => Constants.vsProjectItemKindSolutionItems;

    public override object Object => SubProjectImplementation;

    public override Project SubProject => SubProjectImplementation;

    // ReSharper disable once AssignNullToNotNullAttribute
    public override ProjectItems ProjectItems => null;
}
