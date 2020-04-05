using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public sealed class ProjectItemsImplementation : ProjectItems
    {
        private DteImplementation Implementation { get; }
        private List<ProjectItemModel> ProjectItemModels { get; }

        public ProjectItemsImplementation(
            DteImplementation implementation,
            List<ProjectItemModel> projectItemModels,
            object parent)
        {
            Implementation = implementation;
            ProjectItemModels = projectItemModels;
            Parent = parent;
        }

        public DTE DTE => Implementation;
        public object Parent { get; }
        public int Count => ProjectItemModels.Count;

        [CanBeNull]
        public ProjectItem Item(object index)
        {
            if (!(index is int number)) return null;
            var itemModel = ProjectItemModels.ElementAtOrDefault(number);
            if (itemModel == null) return null;
            return new ProjectItemImplementation(Implementation, itemModel);
        }

        public IEnumerator GetEnumerator() =>
            ProjectItemModels.Select(model => new ProjectItemImplementation(Implementation, model)).GetEnumerator();

        public string Kind => throw new NotImplementedException();
        public Project ContainingProject => throw new NotImplementedException();
        public ProjectItem AddFromFile(string FileName) => throw new NotImplementedException();
        public ProjectItem AddFromTemplate(string FileName, string Name) => throw new NotImplementedException();
        public ProjectItem AddFromDirectory(string Directory) => throw new NotImplementedException();

        public ProjectItem AddFolder(string Name, string Kind = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}") =>
            throw new NotImplementedException();

        public ProjectItem AddFromFileCopy(string FilePath) => throw new NotImplementedException();
    }
}
