using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Util;
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
                switch (DteImplementation.DteProtocolModel.ProjectItem_get_Kind.Sync(new ProjectItemRequest(ProjectItemModel)))
                {
                    case ProjectItemKindModel.PhysicalFile:
                        _subProjectImplementation = null;
                        break;
                    case ProjectItemKindModel.Project:
                        _subProjectImplementation = ImplementationUtil.GetProjectImplementation(
                            DteImplementation, new ProjectItemModel(ProjectItemModel.Id), this);
                        break;
                    case ProjectItemKindModel.PhysicalFolder:
                        _subProjectImplementation = new ProjectImplementation(DteImplementation, new ProjectItemModel(ProjectItemModel.Id), this);
                        break;
                    case ProjectItemKindModel.Unknown:
                    case ProjectItemKindModel.VirtualDirectory:
                    default:
                        return null;
                }
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
