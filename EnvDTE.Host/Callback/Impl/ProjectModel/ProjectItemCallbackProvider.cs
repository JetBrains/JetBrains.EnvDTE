using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.VB;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class ProjectItemCallbackProvider(ISolution solution, ProjectModelViewHost host)
        : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(DteProtocolModel model)
        {
            model.ProjectItem_get_Name.SetWithReadLock(solution.Locks, projectItemModel =>
                GetProjectItem(projectItemModel.Id)?.Name ?? "");

            model.ProjectItem_set_Name.SetWithReadLock(solution.Locks, request =>
            {
                var item = GetProjectItem(request.Model.Id);
                if (item == null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Rename(item, request.NewName));
                return Unit.Instance;
            });

            model.ProjectItem_get_Kind.SetWithReadLock(solution.Locks, projectItemModel =>
                GetProjectItem(projectItemModel.Id)?.Kind switch
                {
                    ProjectItemKind.PHYSICAL_FILE => ProjectItemKindModel.PhysicalFile,
                    ProjectItemKind.PHYSICAL_DIRECTORY => ProjectItemKindModel.PhysicalFolder,
                    ProjectItemKind.PROJECT => ProjectItemKindModel.Project,
                    ProjectItemKind.VIRTUAL_DIRECTORY => ProjectItemKindModel.VirtualDirectory,
                    _ => ProjectItemKindModel.Unknown,
                });

            model.ProjectItem_get_ProjectItems.SetWithReadLock(solution.Locks, projectItemModel =>
                GetProjectFolder(projectItemModel.Id)
                    ?.GetSubItems()
                    .Select(host.GetIdByItem)
                    .Where(id => id != 0)
                    .Select(id => new ProjectItemModel(id))
                    .AsList() ?? new List<ProjectItemModel>());

            model.ProjectItem_get_Language.SetWithReadLock(solution.Locks, projectItemModel =>
                GetProjectFile(projectItemModel.Id)?.ToSourceFile()?.PrimaryPsiLanguage switch
                {
                    CSharpLanguage _ => LanguageModel.CSharp,
                    VBLanguage _ => LanguageModel.VB,
                    _ => LanguageModel.Unknown
                }
            );
        }

        [CanBeNull] private IProjectItem GetProjectItem(int id) => host.GetItemById<IProjectItem>(id);
        [CanBeNull] private IProjectFile GetProjectFile(int id) => host.GetItemById<IProjectFile>(id);

        [CanBeNull] private IProjectFolder GetProjectFolder(int id) => host.GetItemById<IProjectFolder>(id);
    }
}
