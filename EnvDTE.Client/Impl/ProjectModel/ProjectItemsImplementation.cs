using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rd.Tasks;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public class ProjectItemsImplementation(
        [NotNull] DteImplementation dte,
        [NotNull] List<ProjectItemModel> projectItemModels,
        [NotNull] ProjectImplementation containingProject,
        [NotNull] object parent)
        : ProjectItems
    {
        protected DteImplementation DteImplementation => dte;
        protected ProjectImplementation ContainingProjectImplementation => containingProject;

        public DTE DTE => dte;
        public object Parent => parent;
        public Project ContainingProject => containingProject;
        public int Count => projectItemModels.Count;
        public virtual string Kind => Constants.vsProjectItemKindPhysicalFolder;

        [CanBeNull]
        public ProjectItem Item(object index)
        {
            int? intIndex;
            if (index is string name)
                intIndex = dte.DteProtocolModel.ProjectItem_get_SubItemIndex.Sync(
                    new(GetParentItemModel(), name));
            else
                intIndex = ImplementationUtil.GetValidIndexOrThrow(index, projectItemModels.Count);

            if (intIndex is null) return null;

            var itemModel = projectItemModels.ElementAtOrDefault(intIndex.Value);
            return itemModel is null ? null : CreateProjectItem(itemModel);
        }

        public IEnumerator GetEnumerator() => projectItemModels.Select(CreateProjectItem).GetEnumerator();

        [CanBeNull] public ProjectItem AddFromFile([NotNull] string fileName) =>
            AddExistingItem(fileName, dte.DteProtocolModel.ProjectItems_addFromFile);

        [CanBeNull] public ProjectItem AddFromFileCopy([NotNull] string filePath) =>
            AddExistingItem(filePath, dte.DteProtocolModel.ProjectItems_addFromFileCopy);

        [CanBeNull] public ProjectItem AddFromDirectory([NotNull] string directory) =>
            AddExistingItem(directory, dte.DteProtocolModel.ProjectItems_addFromDirectory, isDirectory: true);

        [CanBeNull]
        public ProjectItem AddFolder([NotNull] string name, [NotNull] string kind = Constants.vsProjectItemKindPhysicalFolder)
        {
            var kindModel = kind.ToRdItemKindModel();
            // Only works with PhysicalFolder project item kind in VS (this also means that we don't have to pass the kind to the host)
            if (kindModel != ProjectItemKindModel.PhysicalFolder) throw new ArgumentException(nameof(kind));

            var id = dte.DteProtocolModel.ProjectItems_addFolder.Sync(
                new(GetParentItemModel(), name));
            return id is null ? null : CreateProjectItem(id);
        }

        protected virtual ProjectItemImplementation CreateProjectItem([NotNull] ProjectItemModel projectItemModel) =>
            new(dte, projectItemModel, containingProject);

        [CanBeNull]
        private ProjectItem AddExistingItem(
            [NotNull] string path,
            [NotNull] IRdCall<AddExistingItemRequest, ProjectItemModel> addCall,
            bool isDirectory = false)
        {
            var fullPath = Path.GetFullPath(path);
            // Max timeout because of dialog for external files and long operation in case of directories
            // TODO: Figure out if a better approach is possible
            var id = addCall.Sync(
                new(GetParentItemModel(), fullPath, isDirectory), RpcTimeouts.Maximal);
            return id is null ? null : CreateProjectItem(id);
        }

        private ProjectItemModel GetParentItemModel()
        {
            var id = parent switch
            {
                ProjectImplementation project => project.ProjectModel.Id,
                ProjectItemImplementation projectItem => projectItem.ProjectItemModel.Id,
                _ => throw new InvalidOperationException("Invalid ProjectItems parent")
            };

            return new ProjectItemModel(id);
        }

        #region NotImplemented

        public ProjectItem AddFromTemplate(string FileName, string Name) => throw new NotImplementedException();

        #endregion
    }
}
