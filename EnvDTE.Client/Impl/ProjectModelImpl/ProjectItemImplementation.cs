using System;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.AstImpl;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl
{
    public class ProjectItemImplementation(
        [NotNull] DteImplementation dte,
        [NotNull] ProjectItemModel projectItemModel,
        [NotNull] ProjectImplementation containingProject)
        : ProjectItem
    {
        protected DteImplementation DteImplementation => dte;
        internal ProjectItemModel ProjectItemModel => projectItemModel;

        [NotNull] public DTE DTE => dte;

        public short FileCount => 1;

        [NotNull]
        public string Name
        {
            get => dte.DteProtocolModel.ProjectItem_get_Name.Sync(new(projectItemModel));
            set => dte
                .DteProtocolModel
                .ProjectItem_set_Name
                .Sync(new ProjectItem_set_NameRequest(value, projectItemModel));
        }

        [NotNull] public virtual string Kind =>
            dte.DteProtocolModel.ProjectItem_get_Kind.Sync(new(projectItemModel)).FromRdItemKindModel();

        [CanBeNull]
        public FileCodeModel FileCodeModel
        {
            get
            {
                if (Kind != Constants.vsProjectItemKindPhysicalFile) return null;
                var language = dte.DteProtocolModel.ProjectItem_get_Language.Sync(new (projectItemModel));
                if (!SupportedLanguageUtils.IsSupported(language.ToEnvDTELanguage())) return null;
                return new FileCodeModelImpl(dte, this);
            }
        }

        [NotNull]
        public virtual ProjectItems ProjectItems =>  new ProjectItemsImplementation(dte,
            dte.DteProtocolModel.ProjectItem_get_ProjectItems.Sync(new(projectItemModel)), containingProject, this);

        public ProjectItems Collection => containingProject.ProjectItems;

        public virtual object Object => this;
        public virtual Project SubProject => null;
        public Project ContainingProject => containingProject;

        public void Remove() => dte.DteProtocolModel.ProjectItem_remove.Sync(new(projectItemModel));

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
