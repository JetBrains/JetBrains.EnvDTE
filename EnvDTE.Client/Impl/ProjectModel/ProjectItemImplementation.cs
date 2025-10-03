using System;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Ast;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public class ProjectItemImplementation(
        [NotNull] DteImplementation dte,
        [NotNull] ProjectItemModel projectItemModel,
        [CanBeNull] ProjectImplementation containingProject,
        [CanBeNull] ProjectItemImplementation parent = null)
        : ProjectItem
    {
        protected DteImplementation DteImplementation => dte;
        internal ProjectItemModel ProjectItemModel => projectItemModel;
        [NotNull] public DTE DTE => dte;

        public short FileCount => 1;

        [NotNull]
        public string Name
        {
            get => dte.DteProtocolModel.ProjectItem_get_Name.Sync(projectItemModel);
            set => dte
                .DteProtocolModel
                .ProjectItem_set_Name
                .Sync(new ProjectItem_set_NameRequest(projectItemModel, value));
        }

        [NotNull]
        public virtual string Kind => dte.DteProtocolModel.ProjectItem_get_Kind.Sync(projectItemModel) switch
        {
            ProjectItemKindModel.PhysicalFile => Constants.vsProjectItemKindPhysicalFile,
            ProjectItemKindModel.PhysicalFolder => Constants.vsProjectItemKindPhysicalFolder,
            ProjectItemKindModel.Project => Constants.vsProjectItemKindSubProject,
            ProjectItemKindModel.VirtualDirectory => Constants.vsProjectItemKindVirtualFolder,
            ProjectItemKindModel.Unknown => Constants.vsProjectItemKindUnknown,
            _ => throw new ArgumentOutOfRangeException()
        };

        [CanBeNull]
        public FileCodeModel FileCodeModel
        {
            get
            {
                if (Kind != Constants.vsProjectItemKindPhysicalFile) return null;
                var language = dte.DteProtocolModel.ProjectItem_get_Language.Sync(projectItemModel);
                if (!SupportedLanguageUtils.IsSupported(language.ToEnvDTELanguage())) return null;
                return new FileCodeModelImpl(dte, this);
            }
        }

        [NotNull]
        public virtual ProjectItems ProjectItems =>  new ProjectItemsImplementation(dte,
            dte.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(projectItemModel), containingProject, parent);

        public ProjectItems Collection => parent is null ? containingProject.ProjectItems : parent.ProjectItems;

        public virtual object Object => this;
        public virtual Project SubProject => null;
        public Project ContainingProject => containingProject;

        #region NotImplemented

        public bool IsDirty
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Properties Properties => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();

        public bool Saved
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ConfigurationManager ConfigurationManager => throw new NotImplementedException();
        public Document Document => throw new NotImplementedException();
        public string get_FileNames(short index) => throw new NotImplementedException();
        public bool SaveAs(string NewFileName) => throw new NotImplementedException();

        public bool get_IsOpen(string ViewKind = "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}") =>
            throw new NotImplementedException();

        public Window Open(string ViewKind = "{00000000-0000-0000-0000-000000000000}") =>
            throw new NotImplementedException();

        public void Remove() => throw new NotImplementedException();
        public void ExpandView() => throw new NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();
        public void Save(string FileName = "") => throw new NotImplementedException();
        public void Delete() => throw new NotImplementedException();

        #endregion NotImplemented

        public override bool Equals(object obj) =>
            ReferenceEquals(this, obj) || obj is ProjectItemImplementation other &&
            projectItemModel.Equals(other.ProjectItemModel);

        public override int GetHashCode() => ProjectItemModel.GetHashCode();
    }
}
