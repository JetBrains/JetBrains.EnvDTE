using System;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Props;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public sealed class ProjectImplementation : Project
    {
        private readonly PropertiesImplementation _properties;
        private readonly DteImplementation _dte;
        private readonly Rider.Model.ProjectModel _projectModel;
        [CanBeNull] private ProjectItemsImplementation _projectItems;

        [NotNull, ItemNotNull]
        private List<ProjectItemModel> ProjectItemModels =>
            _dte.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(new ProjectItemModel(_projectModel.Id));

        public string Name
        {
            get => _dte .DteProtocolModel.Project_get_Name.Sync(_projectModel);
            set => _dte.DteProtocolModel.Project_set_Name.Sync(new Project_set_NameRequest(_projectModel, value));
        }

        [NotNull]
        public ProjectItems ProjectItems
        {
            get
            {
                _projectItems ??= new ProjectItemsImplementation(_dte, ProjectItemModels, this, this);
                return _projectItems;
            }
        }

        [NotNull] public DTE DTE => _dte;

        public string FileName => _dte.DteProtocolModel.Project_get_FileName.Sync(_projectModel);

        public string FullName => FileName;

        public string UniqueName => _dte.DteProtocolModel.Project_get_UniqueName.Sync(_projectModel);

        public Projects Collection => _dte.Solution.Projects;

        public void Delete() => _dte.DteProtocolModel.Project_Delete.Sync(_projectModel);

        [CanBeNull] public ProjectItem ParentProjectItem { get; }

        public Properties Properties => _properties;

        public string Kind => _dte.DteProtocolModel.Project_get_Kind.Sync(_projectModel);

        public object Object => this;

        public ProjectImplementation(
            [NotNull] DteImplementation dte,
            [NotNull] Rider.Model.ProjectModel projectModel,
            [CanBeNull] ProjectItemImplementation parentProjectItem = null)
        {
            _dte = dte;
            _projectModel = projectModel;
            ParentProjectItem = parentProjectItem;

            var projectItemModels = _dte.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(new ProjectItemModel(projectModel.Id));
            _projectItems =
                Constants.vsProjectKindSolutionItems.Equals(_dte.DteProtocolModel.Project_get_Kind.Sync(projectModel))
                    ? new SolutionFolderProjectItemsImplementation(dte, projectItemModels, this, parentProjectItem)
                    : new ProjectItemsImplementation(dte, projectItemModels, this, parentProjectItem);

            _properties = new PropertiesImplementation(_dte, this, arg =>
            {
                if (arg is not string key) throw new ArgumentException();

                if (!VisualStudioProperties.Map.TryGetValue(key, out var propertyInfo))
                    return new NullPropertyImplementation(dte, _properties!, key);

                return new PropertyImplementation(dte, _properties!, propertyInfo,
                    name =>
                        _dte.DteProtocolModel.Project_get_Property.Sync(new(_projectModel, name)),
                    (name, value) =>
                        _dte.DteProtocolModel.Project_set_Property.Sync(new(_projectModel, name, value)));
            });
        }

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

        public ConfigurationManager ConfigurationManager => throw new NotImplementedException();
        public Globals Globals => throw new NotImplementedException();
        public CodeModel CodeModel => throw new NotImplementedException();
        public void SaveAs(string NewFileName) => throw new NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();
        public void Save(string FileName = "") => throw new NotImplementedException();

        #endregion
    }
}
