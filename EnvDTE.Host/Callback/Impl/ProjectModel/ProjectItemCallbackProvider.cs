using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.Components;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.DocumentManagers.Transactions;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.VB;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class ProjectItemCallbackProvider(
        ILogger logger,
        ISolution solution,
        ProjectModelViewHost host,
        ISimpleLazy<IProjectModelEditor> projectModelEditor)
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
                GetFilteredProjectItems(projectItemModel)
                    .Select(item => new ProjectItemModel(host.GetIdByItem(item)))
                    .AsList());

            model.ProjectItem_get_Language.SetWithReadLock(solution.Locks, projectItemModel =>
                GetProjectFile(projectItemModel.Id)?.ToSourceFile()?.PrimaryPsiLanguage switch
                {
                    CSharpLanguage _ => LanguageModel.CSharp,
                    VBLanguage _ => LanguageModel.VB,
                    _ => LanguageModel.Unknown
                }
            );

            model.ProjectItem_remove.SetVoidAsync(async (lifetime, projectItemModel) =>
            {
                var projectItem = GetProjectItem(projectItemModel.Id);
                if (projectItem is null) return;

                logger.Trace($"Removing project item '{projectItem.Name}'");
                await lifetime.StartMainWrite(() => projectModelEditor.Value.Remove(projectItem));
            });

            model.ProjectItem_get_SubItemIndex.SetAsync(async (lifetime, args) =>
            {
                string[] itemNames = null;
                await lifetime.StartReadActionAsync(() =>
                {
                    itemNames = GetFilteredProjectItems(args.Item).Select(item => item.Name).ToArray();
                });
                var index =  itemNames.IndexOf(args.Name, StringComparer.OrdinalIgnoreCase);
                return index == -1 ? null : index;
            });
        }

        [CanBeNull] private IProjectItem GetProjectItem(int id) => host.GetItemById<IProjectItem>(id);
        [CanBeNull] private IProjectFile GetProjectFile(int id) => host.GetItemById<IProjectFile>(id);

        private IEnumerable<IProjectItem> GetFilteredProjectItems(ProjectItemModel projectItemModel)
        {
            var rootItem = host.GetItemById<IProjectFolder>(projectItemModel.Id);
            if (rootItem is null) return [];

            // If we are returning subitems of a project, the project file should not be returned
            IProjectFile projectFile = null;
            if (rootItem is IProject project) projectFile = project.ProjectFile;

            // I Removed id != 0 model id filter, it shouldn't be a problem because we filter out hidden items
            return rootItem.GetSubItems().Where(item => item switch
            {
                ProjectFolderImpl folder => !folder.IsHidden,
                IProjectFile file => projectFile is null || !file.Equals(projectFile),
                _ => true
            });
        }
    }
}
