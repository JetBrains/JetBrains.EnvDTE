using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public sealed class ProjectItemsImplementation : ProjectItems
    {
        private DteImplementation Implementation { get; }
        private List<ProjectItemModel> ProjectItems { get; }

        public ProjectItemsImplementation(DteImplementation implementation, List<ProjectItemModel> projectItems)
        {
            Implementation = implementation;
            ProjectItems = projectItems;
        }

        public DTE DTE => Implementation;
        public object Parent => throw new NotImplementedException();
        public int Count => throw new NotImplementedException();
        public string Kind => throw new NotImplementedException();
        public Project ContainingProject => throw new NotImplementedException();
        public ProjectItem Item(object index) => throw new NotImplementedException();
        IEnumerator ProjectItems.GetEnumerator() => throw new NotImplementedException();
        public ProjectItem AddFromFile(string FileName) => throw new NotImplementedException();
        public ProjectItem AddFromTemplate(string FileName, string Name) => throw new NotImplementedException();
        public ProjectItem AddFromDirectory(string Directory) => throw new NotImplementedException();

        public ProjectItem AddFolder(string Name, string Kind = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}") =>
            throw new NotImplementedException();

        public ProjectItem AddFromFileCopy(string FilePath) => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    }
}
