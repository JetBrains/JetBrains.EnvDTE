using System;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ConfigurationImpl;
using JetBrains.EnvDTE.Client.Impl.PropertyImpl;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl
{
    public sealed class ProjectImplementation(
        [NotNull] DteImplementation dte,
        [NotNull] ProjectItemModel projectModel,
        [CanBeNull] ProjectItemImplementation parentProjectItem = null)
        : Project
    {
        [CanBeNull] private ProjectPropertiesImplementation _properties;
        private readonly DteImplementation _dte = dte;

        [NotNull, ItemNotNull]
        private List<ProjectItemModel> ProjectItemModels =>
            _dte.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(new(projectModel));

        public string Name
        {
            get => _dte.DteProtocolModel.Project_get_Name.Sync(new(projectModel));
            set => _dte.DteProtocolModel.Project_set_Name.Sync(new(value, projectModel));
        }

        [NotNull]
        public ProjectItems ProjectItems => Constants.vsProjectKindSolutionItems.Equals(Kind)
            ? new SolutionFolderProjectItemsImplementation(_dte, this, this, projectModel)
            : new ProjectItemsImplementation(_dte, this, this, projectModel);

        [NotNull] public DTE DTE => _dte;

        public string FileName => _dte.DteProtocolModel.Project_get_FileName.Sync(new(projectModel));

        public string FullName => FileName;

        public string UniqueName => _dte.DteProtocolModel.Project_get_UniqueName.Sync(new(projectModel));

        public Projects Collection => _dte.Solution.Projects;

        public void Delete() => _dte.DteProtocolModel.Project_Delete.Sync(new(projectModel));

        [CanBeNull] public ProjectItem ParentProjectItem { get; } = parentProjectItem;

        public Properties Properties
        {
            get
            {
                _properties ??= new ProjectPropertiesImplementation(_dte, this, projectModel);
                return _properties;
            }
        }

        public string Kind => _dte.DteProtocolModel.Project_get_Kind.Sync(new(projectModel));

        public object Object => this;

        public ConfigurationManager ConfigurationManager { get; } =
            new ConfigurationManagerImplementation(dte, projectModel);

        /// <summary>
        /// Retrieves a Project by traversing from root down through the item hierarchy.
        /// </summary>
        /// <param name="dte">The DTE instance.</param>
        /// <param name="pathItems">The project item path, starting with the top-level project.</param>
        public static ProjectImplementation GetFromPath(
            [NotNull] DteImplementation dte,
            [NotNull] IReadOnlyList<ProjectItemModel> pathItems)
        {
            if (pathItems.Count == 0) throw new ArgumentException("Path must contain at least one item", nameof(pathItems));
            if (pathItems.Count == 1) return new ProjectImplementation(dte, pathItems[0]);

            var currentProject = ((ProjectsImplementation)dte.Solution.Projects).Item(pathItems[0]);
            for (var i = 1; i < pathItems.Count; i++)
            {
                var projectItems = (ProjectItemsImplementation)currentProject.ProjectItems;
                currentProject = (ProjectImplementation)projectItems.Item(pathItems[i]).SubProject;
            }

            return currentProject;
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

        public Globals Globals => throw new NotImplementedException();
        public CodeModel CodeModel => throw new NotImplementedException();
        public void SaveAs(string NewFileName) => throw new NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();
        public void Save(string FileName = "") => throw new NotImplementedException();

        #endregion
    }
}
