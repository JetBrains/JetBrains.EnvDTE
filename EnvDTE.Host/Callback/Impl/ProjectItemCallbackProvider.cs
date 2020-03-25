using System.Collections.Generic;
using System.Linq;
using JetBrains.Core;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class ProjectItemCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(ConnectionManager manager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            model.ProjectItem_get_Name.SetWithReadLock(projectItemModel =>
                host.GetItemById<IProjectItem>(projectItemModel.Id)?.Name ?? "");
            model.ProjectItem_set_Name.SetWithReadLock(request =>
            {
                var item = host.GetItemById<IProjectItem>(request.Model.Id);
                if (item == null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Rename(item, request.NewName));
                return Unit.Instance;
            });
            model.ProjectItem_get_Kind.SetWithReadLock(projectItemModel =>
                host.GetItemById<IProjectItem>(projectItemModel.Id)?.Kind switch
                {
                    ProjectItemKind.PHYSICAL_FILE => ProjectItemKindModel.PhysicalFile,
                    ProjectItemKind.PHYSICAL_DIRECTORY => ProjectItemKindModel.PhysicalFolder,
                    ProjectItemKind.PROJECT => ProjectItemKindModel.Project,
                    ProjectItemKind.VIRTUAL_DIRECTORY => ProjectItemKindModel.VirtualDirectory,
                    _ => ProjectItemKindModel.Unknown,
                });
            model.ProjectItem_get_ProjectItems.SetWithReadLock(projectItemModel => host
                .GetItemById<IProject>(projectItemModel.Id)
                ?.GetSubItems()
                .Select(host.GetIdByItem)
                .Where(id => id != 0)
                .Select(id => new ProjectItemModel(id))
                .AsList() ?? new List<ProjectItemModel>());
        }
    }
}
