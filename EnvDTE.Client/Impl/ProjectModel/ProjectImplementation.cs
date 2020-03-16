using System;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public sealed class ProjectImplementation : Project
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        [NotNull]
        private Rider.Model.ProjectModel ProjectModel { get; }

        [NotNull, ItemNotNull]
        private List<ProjectItemModel> ProjectItemModels =>
            Implementation.DteProtocolModel.Project_get_ProjectItems.Sync(ProjectModel);

        public ProjectImplementation(
            [NotNull] DteImplementation implementation,
            [NotNull] Rider.Model.ProjectModel projectModel,
            [CanBeNull] ProjectItem parentProjectItem = null
        )
        {
            Implementation = implementation;
            ProjectModel = projectModel;
            ParentProjectItem = parentProjectItem;
        }

        public string Name
        {
            get => Implementation
                .DteProtocolModel
                .Project_get_Name
                .Sync(ProjectModel);
            set => Implementation
                .DteProtocolModel
                .Project_set_Name
                .Sync(new Project_set_NameRequest(ProjectModel, value));
        }

        [NotNull]
        public ProjectItems ProjectItems => new ProjectItemsImplementation(Implementation, ProjectItemModels, this);

        [NotNull]
        public DTE DTE => Implementation;

        public string FileName => Implementation.DteProtocolModel.Project_get_FileName.Sync(ProjectModel);
        public string FullName => FileName;
        public Projects Collection => Implementation.Solution.Projects;
        public void Delete() => Implementation.DteProtocolModel.Project_Delete.Sync(ProjectModel);
        public ProjectItem ParentProjectItem { get; }

        public bool IsDirty
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Kind => throw new NotImplementedException();
        public Properties Properties => throw new NotImplementedException();
        public string UniqueName => throw new NotImplementedException();
        public object Object => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();

        public bool Saved
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ConfigurationManager ConfigurationManager => throw new NotImplementedException();
        public Globals Globals => throw new NotImplementedException();
        public CodeModel CodeModel => throw new NotImplementedException();
        public void SaveAs(string NewFileName) => throw new NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();
        public void Save(string FileName = "") => throw new NotImplementedException();
    }
}
