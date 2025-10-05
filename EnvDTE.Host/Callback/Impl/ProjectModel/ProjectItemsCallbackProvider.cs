using System;
using System.Threading.Tasks;
using JetBrains.Application.Components;
using JetBrains.Application.Parts;
using JetBrains.DocumentManagers.Transactions;
using JetBrains.DocumentManagers.Transactions.ProjectHostActions.Modifications;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel;

[SolutionComponent(Instantiation.DemandAnyThreadSafe)]
public class ProjectItemsCallbackProvider(
    ISolution solution,
    ProjectModelViewHost host,
    ISimpleLazy<IProjectModelEditor> projectModelEditor) : IEnvDteCallbackProvider
{
    public void RegisterCallbacks(DteProtocolModel model)
    {
        model.ProjectItems_addFolder.SetAsync(AddFolderAsync);
        model.ProjectItems_addFromFile.SetAsync((lifetime, request) =>
            AddExistingItemAsync(lifetime, request));
        model.ProjectItems_addFromDirectory.SetAsync((lifetime, request) =>
            AddExistingItemAsync(lifetime, request, copyBeforeAdd: true));
        model.ProjectItems_addFromFileCopy.SetAsync((lifetime, request) =>
            AddExistingItemAsync(lifetime, request, copyBeforeAdd: true));
    }

    private async Task<ProjectItemModel> AddFolderAsync(Lifetime lifetime, ProjectItems_addFolderRequest request)
    {
        var parentFolder = GetParentFolder(request.ParentItem.Id);
        if (parentFolder is null) return null;

        IProjectFolder result = null;
        await lifetime.StartMainWrite(() =>
        {
            result = projectModelEditor.Value.AddFolder(parentFolder, request.Name);
        });

        return result is null
            ? null
            : new ProjectItemModel(host.GetIdByItem(result));
    }

    private async Task<ProjectItemModel> AddExistingItemAsync(
        Lifetime lifetime,
        AddExistingItemRequest request,
        bool copyBeforeAdd = false)
    {
        var parentFolder = GetParentFolder(request.ParentItem.Id);
        if (parentFolder is null) return null;

        var sourcePath = VirtualFileSystemPath.Parse(request.Path, InteractionContext.SolutionContext);
        if (request.IsDirectory && !sourcePath.ExistsDirectory || !request.IsDirectory && !sourcePath.ExistsFile) return null;

        if (sourcePath.Equals(parentFolder.Location)) return null;
        if (sourcePath.IsPrefixOf(parentFolder.Location)) return null;

        if (copyBeforeAdd)
        {
            var destinationPath = parentFolder.Location / sourcePath.Name;

            try
            {
                sourcePath.Copy(destinationPath, false);
            }
            catch (Exception)
            {
                return null;
            }

            sourcePath = destinationPath;
        }

        IProjectItem result = null;
        await lifetime.StartMainWrite(() =>
            // TODO: Maybe ordering context is necessary
            solution.InvokeUnderTransaction(cookie =>
            {
                AddItemTaskAction action;
                if (parentFolder.IsSolutionFolder())
                    action = new AddItemInSolutionFolder(lifetime, cookie, parentFolder, sourcePath);
                else if (parentFolder.Location.IsPrefixOf(sourcePath))
                    action = new AddItemPreserveDirectoriesTaskAction(lifetime, cookie, parentFolder, sourcePath);
                else
                    action = new AddItemAsLinkTaskAction(lifetime, cookie, parentFolder, sourcePath);

                result = action.Execute();
            }));

        return result is null
            ? null
            : new ProjectItemModel(host.GetIdByItem(result));
    }

    private IProjectFolder GetParentFolder(int id) => host.GetItemById<IProjectFolder>(id);
}
