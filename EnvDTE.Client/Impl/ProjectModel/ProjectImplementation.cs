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
        [NotNull] private readonly DteImplementation _dte;
        [NotNull] private readonly Rider.Model.ProjectModel _projectModel;
        [NotNull] private readonly PropertiesImplementation _properties;

        [NotNull] private DteImplementation Implementation => _dte;

        [NotNull] private Rider.Model.ProjectModel ProjectModel => _projectModel;

        [NotNull, ItemNotNull]
        private List<ProjectItemModel> ProjectItemModels =>
            Implementation.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(new ProjectItemModel(ProjectModel.Id));

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

        [NotNull] public DTE DTE => Implementation;

        public string FileName => Implementation.DteProtocolModel.Project_get_FileName.Sync(ProjectModel);
        public string FullName => FileName;
        public Projects Collection => Implementation.Solution.Projects;
        public void Delete() => Implementation.DteProtocolModel.Project_Delete.Sync(ProjectModel);

        [CanBeNull] public ProjectItem ParentProjectItem { get; }

        public Properties Properties => _properties;
        public string Kind => Implementation.DteProtocolModel.Project_get_Kind.Sync(ProjectModel);

        public ProjectImplementation(
            [NotNull] DteImplementation dte,
            [NotNull] Rider.Model.ProjectModel projectModel,
            [CanBeNull] ProjectItem parentProjectItem = null)
        {
            _dte = dte;
            _projectModel = projectModel;
            ParentProjectItem = parentProjectItem;

            _properties = new PropertiesImplementation(Implementation, this, arg =>
            {
                if (arg is not string key) throw new ArgumentException();

                var propertyType =
                    Implementation.DteProtocolModel.Project_getType_Property.Sync(new(ProjectModel, key));

                return propertyType switch
                {
                    RdPropertyType.Null => new NullPropertyImplementation(_dte, _properties, key),
                    RdPropertyType.Regular => new PropertyImplementation(_dte, _properties, key,
                        () =>
                            _dte.DteProtocolModel.Project_get_Property.Sync(new(_projectModel, key)),
                        value =>
                            _dte.DteProtocolModel.Project_set_Property.Sync(new(_projectModel, key, value))),
                    RdPropertyType.ReadOnly => new ReadOnlyPropertyImplementation(_dte, _properties, key, () =>
                        _dte.DteProtocolModel.Project_get_Property.Sync(new(_projectModel, key))),
                    _ => throw new ArgumentOutOfRangeException($"Invalid property type: {propertyType}")
                };
            });
        }

        #region NotImplemented

        public bool IsDirty
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

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

        #endregion
    }
}
