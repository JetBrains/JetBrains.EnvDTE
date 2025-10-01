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
        [NotNull] private readonly PropertiesImplementation _properties;

        [NotNull] private DteImplementation Implementation { get; }

        [NotNull] private Rider.Model.ProjectModel ProjectModel { get; }

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

        public string UniqueName => Implementation.DteProtocolModel.Project_get_UniqueName.Sync(ProjectModel);

        public Projects Collection => Implementation.Solution.Projects;

        public void Delete() => Implementation.DteProtocolModel.Project_Delete.Sync(ProjectModel);

        [CanBeNull] public ProjectItem ParentProjectItem { get; }

        public Properties Properties => _properties;

        public string Kind => Implementation.DteProtocolModel.Project_get_Kind.Sync(ProjectModel);

        public object Object => this;

        public ProjectImplementation(
            [NotNull] DteImplementation dte,
            [NotNull] Rider.Model.ProjectModel projectModel,
            [CanBeNull] ProjectItem parentProjectItem = null)
        {
            Implementation = dte;
            ProjectModel = projectModel;
            ParentProjectItem = parentProjectItem;

            _properties = new PropertiesImplementation(Implementation, this, arg =>
            {
                if (arg is not string key) throw new ArgumentException();

                if (!VisualStudioProperties.Map.TryGetValue(key, out var propertyInfo))
                    return new NullPropertyImplementation(dte, _properties!, key);

                return new PropertyImplementation(dte, _properties!, propertyInfo,
                    name =>
                        Implementation.DteProtocolModel.Project_get_Property.Sync(new(ProjectModel, name)),
                    (name, value) =>
                        Implementation.DteProtocolModel.Project_set_Property.Sync(new(ProjectModel, name, value)));
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
