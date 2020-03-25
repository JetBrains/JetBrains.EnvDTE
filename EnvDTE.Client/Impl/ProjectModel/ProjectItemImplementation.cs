using System;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Model;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public sealed class ProjectItemImplementation : ProjectItem
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        [NotNull]
        internal ProjectItemModel ProjectItemModel { get; }

        public ProjectItemImplementation(
            [NotNull] DteImplementation implementation,
            [NotNull] ProjectItemModel projectItemModel
        )
        {
            Implementation = implementation;
            ProjectItemModel = projectItemModel;
        }

        [NotNull]
        public DTE DTE => Implementation;

        public short FileCount => 1;

        [NotNull]
        public string Name
        {
            get => Implementation.DteProtocolModel.ProjectItem_get_Name.Sync(ProjectItemModel);
            set => Implementation
                .DteProtocolModel
                .ProjectItem_set_Name
                .Sync(new ProjectItem_set_NameRequest(ProjectItemModel, value));
        }

        [NotNull]
        public string Kind => Implementation.DteProtocolModel.ProjectItem_get_Kind.Sync(ProjectItemModel) switch
        {
            ProjectItemKindModel.PhysicalFile => Constants.vsProjectItemKindPhysicalFile,
            ProjectItemKindModel.PhysicalFolder => Constants.vsProjectItemKindPhysicalFolder,
            ProjectItemKindModel.Project => Constants.vsProjectItemKindSubProject,
            ProjectItemKindModel.VirtualDirectory => Constants.vsProjectItemKindVirtualFolder,
            _ => Constants.vsProjectItemKindUnknown
        };

        [CanBeNull]
        public FileCodeModel FileCodeModel
        {
            get
            {
                if (Kind != Constants.vsProjectItemKindPhysicalFile) return null;
                return new FileCodeModelImpl(Implementation, this);
            }
        }

        [NotNull]
        public ProjectItems ProjectItems => new ProjectItemsImplementation(
            Implementation,
            Implementation.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(ProjectItemModel),
            this
        );

        public bool IsDirty
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ProjectItems Collection => throw new NotImplementedException();
        public Properties Properties => throw new NotImplementedException();
        public object Object => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();

        public bool Saved
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ConfigurationManager ConfigurationManager => throw new NotImplementedException();
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
