using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Util;
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
        public int Count => projectItemModels.Count;
        public virtual string Kind => Constants.vsProjectItemKindPhysicalFolder;

        [CanBeNull]
        public ProjectItem Item(object index)
        {
            var i = ImplementationUtil.GetValidIndexOrThrow(index, projectItemModels.Count);
            var itemModel = projectItemModels.ElementAtOrDefault(i);
            return itemModel is null ? null : CreateProjectItem(itemModel);
        }

        protected virtual ProjectItemImplementation CreateProjectItem(ProjectItemModel projectItemModel) =>
            new(dte, projectItemModel, containingProject);

        public IEnumerator GetEnumerator() =>
            projectItemModels.Select(CreateProjectItem).GetEnumerator();

        #region NotImplemented

        public Project ContainingProject => throw new NotImplementedException();
        public ProjectItem AddFromFile(string FileName) => throw new NotImplementedException();
        public ProjectItem AddFromTemplate(string FileName, string Name) => throw new NotImplementedException();
        public ProjectItem AddFromDirectory(string Directory) => throw new NotImplementedException();

        public ProjectItem AddFolder(string Name, string Kind = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}") =>
            throw new NotImplementedException();

        public ProjectItem AddFromFileCopy(string FilePath) => throw new NotImplementedException();

        #endregion
    }
}
