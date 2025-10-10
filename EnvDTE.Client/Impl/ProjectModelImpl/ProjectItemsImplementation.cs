using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Lifetimes;
using JetBrains.Rd.Tasks;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl
{
    public class ProjectItemsImplementation(
        [NotNull] DteImplementation dte,
        [NotNull] ProjectImplementation containingProject,
        [NotNull] object parent,
        [NotNull] ProjectItemModel parentItemModel)
        : ProjectItems
    {
        private IEnumerable<ProjectItemModel> ProjectItemModels =>
            dte.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(new(parentItemModel));

        protected DteImplementation DteImplementation => dte;
        protected ProjectImplementation ContainingProjectImplementation => containingProject;

        public DTE DTE => dte;
        public object Parent => parent;
        public Project ContainingProject => containingProject;
        public int Count => dte.DteProtocolModel.ProjectItem_get_ProjectItemCount.Sync(new(parentItemModel));
        public virtual string Kind => Constants.vsProjectItemKindPhysicalFolder;

        [CanBeNull]
        public ProjectItem Item(object index)
        {
            int? intIndex;
            if (index is string name)
                intIndex = dte.DteProtocolModel.ProjectItem_get_SubItemIndex.Sync(
                    new(name, parentItemModel));
            else
                intIndex = ImplementationUtil.GetValidIndexOrThrow(index, Count);

            if (intIndex is null) return null;

            var itemModel = ProjectItemModels.ElementAtOrDefault(intIndex.Value);
            return itemModel is null ? null : CreateProjectItem(itemModel);
        }

        public IEnumerator GetEnumerator() => ProjectItemModels.Select(CreateProjectItem).GetEnumerator();

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
                new(name, parentItemModel));
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
            // This operation could take a long time, so call it asynchronously to avoid the timeout
            // TODO: Figure out if its possible to enable cancellation
            var id = addCall.Start(dte.DteLifetime,
                new(fullPath, isDirectory, parentItemModel)).GetAwaiter().GetResult();
            return id is null ? null : CreateProjectItem(id);
        }

        #region NotImplemented

        public ProjectItem AddFromTemplate(string FileName, string Name) => throw new NotImplementedException();

        #endregion
    }
}
