using System;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ConfigurationImpl;
using JetBrains.EnvDTE.Client.Impl.PropertiesImpl;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl
{
    public sealed class ProjectImplementation(
        [NotNull] DteImplementation dte,
        [NotNull] ProjectModel projectModel,
        [CanBeNull] ProjectItemImplementation parentProjectItem = null)
        : Project
    {
        [CanBeNull] private ProjectPropertiesImplementation _properties;
        private readonly DteImplementation _dte = dte;
        internal readonly ProjectModel ProjectModel = projectModel;

        [NotNull, ItemNotNull]
        private List<ProjectItemModel> ProjectItemModels =>
            _dte.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(new ProjectItemModel(ProjectModel.Id));

        public string Name
        {
            get => _dte .DteProtocolModel.Project_get_Name.Sync(ProjectModel);
            set => _dte.DteProtocolModel.Project_set_Name.Sync(new Project_set_NameRequest(ProjectModel, value));
        }

        [NotNull]
        public ProjectItems ProjectItems => Constants.vsProjectKindSolutionItems.Equals(Kind)
                        ? new SolutionFolderProjectItemsImplementation(_dte, ProjectItemModels, this, this)
                        : new ProjectItemsImplementation(_dte, ProjectItemModels, this, this);

        [NotNull] public DTE DTE => _dte;

        public string FileName => _dte.DteProtocolModel.Project_get_FileName.Sync(ProjectModel);

        public string FullName => FileName;

        public string UniqueName => _dte.DteProtocolModel.Project_get_UniqueName.Sync(ProjectModel);

        public Projects Collection => _dte.Solution.Projects;

        public void Delete() => _dte.DteProtocolModel.Project_Delete.Sync(ProjectModel);

        [CanBeNull] public ProjectItem ParentProjectItem { get; } = parentProjectItem;

        public Properties Properties
        {
            get
            {
                _properties ??= new ProjectPropertiesImplementation(_dte, this, ProjectModel);
                return _properties;
            }
        }

        public string Kind => _dte.DteProtocolModel.Project_get_Kind.Sync(ProjectModel);

        public object Object => this;

        public ConfigurationManager ConfigurationManager { get; } = new ConfigurationManagerImplementation(dte, projectModel);

        #region NotImplemented

        public bool IsDirty
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();

        public bool Saved
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Globals Globals => throw new NotImplementedException();
        public CodeModel CodeModel => throw new NotImplementedException();
        public void SaveAs(string NewFileName) => throw new NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();
        public void Save(string FileName = "") => throw new NotImplementedException();

        #endregion
    }
}
