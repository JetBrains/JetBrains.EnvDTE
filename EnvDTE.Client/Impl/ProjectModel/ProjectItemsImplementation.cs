using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public class ProjectItemsImplementation(
        [NotNull] DteImplementation dte,
        [NotNull] List<ProjectItemModel> projectItemModels,
        [NotNull] ProjectImplementation containingProject,
        [NotNull] object parent,
        [CanBeNull] ProjectItemImplementation projectItem = null
        )
        : ProjectItems
    {
        protected DteImplementation DteImplementation => dte;
        protected ProjectItemImplementation ParentProjectItemImplementation => projectItem;
        protected ProjectImplementation ContainingProjectImplementation => containingProject;

        public DTE DTE => dte;
        public object Parent => parent;
        public int Count => projectItemModels.Count;
        public virtual string Kind => Constants.vsProjectItemKindPhysicalFolder;

        [CanBeNull]
        public ProjectItem Item(object index)
        {
            // Project items list is 1-based in VS
            if (index is not int number) throw new ArgumentOutOfRangeException(nameof(index));
            if (number < 1 || number > projectItemModels.Count) throw new ArgumentOutOfRangeException(nameof(index));

            var itemModel = projectItemModels.ElementAtOrDefault(number - 1);
            return itemModel is null ? null : CreateProjectItem(itemModel);
        }

        protected virtual ProjectItemImplementation CreateProjectItem(ProjectItemModel projectItemModel) =>
            new(dte, projectItemModel, containingProject, projectItem);

        public IEnumerator GetEnumerator() =>
            projectItemModels.Select(model => new ProjectItemImplementation(dte, model, containingProject, projectItem)).GetEnumerator();

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
