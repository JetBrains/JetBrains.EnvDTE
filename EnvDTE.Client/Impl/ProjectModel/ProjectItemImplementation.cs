using System;
using EnvDTE;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public sealed class ProjectItemImplementation : ProjectItem
    {
        private DteImplementation Implementation { get; }
        private ProjectItemModel ProjectItemModel { get; }

        public ProjectItemImplementation(DteImplementation implementation, ProjectItemModel projectItemModel)
        {
            Implementation = implementation;
            ProjectItemModel = projectItemModel;
        }

        public DTE DTE => Implementation;
        public short FileCount => 1;

        public string Name
        {
            get => Implementation.DteProtocolModel.ProjectItem_get_Name.Sync(ProjectItemModel);
            set => Implementation
                .DteProtocolModel
                .ProjectItem_set_Name
                .Sync(new ProjectItem_set_NameRequest(ProjectItemModel, value));
        }

        public bool IsDirty
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ProjectItems Collection => throw new NotImplementedException();
        public Properties Properties => throw new NotImplementedException();
        public string Kind => throw new NotImplementedException();
        public ProjectItems ProjectItems => throw new NotImplementedException();
        public object Object => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();

        public bool Saved
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ConfigurationManager ConfigurationManager => throw new NotImplementedException();
        public FileCodeModel FileCodeModel => throw new NotImplementedException();
        public Document Document => throw new NotImplementedException();
        public Project SubProject => throw new NotImplementedException();
        public Project ContainingProject => throw new NotImplementedException();
        public string get_FileNames(short index) => throw new System.NotImplementedException();
        public bool SaveAs(string NewFileName) => throw new System.NotImplementedException();

        public bool get_IsOpen(string ViewKind = "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}") =>
            throw new NotImplementedException();

        public Window Open(string ViewKind = "{00000000-0000-0000-0000-000000000000}") =>
            throw new NotImplementedException();

        public void Remove() => throw new System.NotImplementedException();
        public void ExpandView() => throw new System.NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new System.NotImplementedException();
        public void Save(string FileName = "") => throw new System.NotImplementedException();
        public void Delete() => throw new System.NotImplementedException();
    }
}
