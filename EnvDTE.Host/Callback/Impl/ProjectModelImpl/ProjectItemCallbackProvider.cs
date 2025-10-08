using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Components;
using JetBrains.Application.Parts;
using JetBrains.DocumentManagers.Transactions;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.VB;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl
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
            model.ProjectItem_get_Name.SetWithProjectItemAsync(host, async (lifetime, _, projectItem) =>
                await lifetime.StartReadActionAsync(() => projectItem.Name));

            model.ProjectItem_set_Name.SetWithProjectItemVoidAsync(host, (lifetime, req, projectItem) =>
                lifetime.StartReadActionAsync(() =>
                    solution.InvokeUnderTransaction(cookie => cookie.Rename(projectItem, req.NewName))));

            model.ProjectItem_get_Kind.SetWithProjectItemAsync(host, (lifetime, _, projectItem) =>
                lifetime.StartReadActionAsync(() =>
                    projectItem.Kind switch
                    {
                        ProjectItemKind.PHYSICAL_FILE => ProjectItemKindModel.PhysicalFile,
                        ProjectItemKind.PHYSICAL_DIRECTORY => ProjectItemKindModel.PhysicalFolder,
                        ProjectItemKind.PROJECT => ProjectItemKindModel.Project,
                        ProjectItemKind.VIRTUAL_DIRECTORY => ProjectItemKindModel.VirtualDirectory,
                        _ => ProjectItemKindModel.Unknown,
                    }));

            model.ProjectItem_get_ProjectItems.SetWithProjectItemAsync(host, (lifetime, _, projectItem) =>
                lifetime.StartReadActionAsync(() => GetFilteredProjectItems(projectItem)
                    .Select(item => new ProjectItemModel(host.GetIdByItem(item)))
                    .AsList()));

            model.ProjectItem_get_ProjectItemCount.SetWithProjectItemAsync(host, (lifetime, _, projectItem) =>
                lifetime.StartReadActionAsync(() => GetFilteredProjectItems(projectItem).Count()));

            model.ProjectItem_get_Language.SetWithProjectItemAsync(host, async (lifetime, _, projectItem) =>
            {
                if (projectItem is not IProjectFile projectFile)
                {
                    logger.Warn($"Project item '{projectItem.Name}' is not a file.");
                    return LanguageModel.Unknown;;
                }

                return await lifetime.StartReadActionAsync(() =>
                    projectFile.ToSourceFile()?.PrimaryPsiLanguage switch
                    {
                        CSharpLanguage _ => LanguageModel.CSharp,
                        VBLanguage _ => LanguageModel.VB,
                        _ => LanguageModel.Unknown
                    });
            });

            model.ProjectItem_remove.SetWithProjectItemVoidAsync(host, async (lifetime, _, projectItem) =>
            {
                logger.Trace($"Removing project item '{projectItem.Name}'");
                await lifetime.StartMainWrite(() => projectModelEditor.Value.Remove(projectItem));
            });

            model.ProjectItem_get_SubItemIndex.SetWithProjectItemAsync(host, async (lifetime, req, projectItem) =>
            {
                var itemNames = await lifetime.StartReadActionAsync(() =>
                    GetFilteredProjectItems(projectItem).Select(item => item.Name).ToArray());
                var index =  itemNames.IndexOf(req.Name, StringComparer.OrdinalIgnoreCase);
                return index == -1 ? null : index;
            });
        }

        private IEnumerable<IProjectItem> GetFilteredProjectItems(IProjectItem projectItem)
        {
            if (projectItem is not IProjectFolder rootItem) return [];

            // If we are returning subitems of a project, the project file should not be returned
            IProjectFile projectFile = null;
            if (rootItem is IProject project) projectFile = project.ProjectFile;

            // Even though we filter out hidden items, in some edge cases it happens that visible items have an id of 0
            // So we have to check for that as well.
            return rootItem.GetSubItems().Where(item => item switch
            {
                ProjectFolderImpl folder => !folder.IsHidden,
                IProjectFile file => projectFile is null || !file.Equals(projectFile),
                _ => true
            }).Where(item => host.GetIdByItem(item) != 0);
        }
    }
}
