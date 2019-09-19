using System;
using com.jetbrains.rider.model;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl
{
    public class ProjectImplementation : Project
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        private ProjectModel ProjectModel { get; }

        public ProjectImplementation([NotNull] DteImplementation implementation, ProjectModel projectModel)
        {
            Implementation = implementation;
            ProjectModel = projectModel;
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

        public DTE DTE => Implementation;
        public string FileName => Implementation.DteProtocolModel.Project_get_FileName.Sync(ProjectModel);
        public bool IsDirty { get; set; }
        public Projects Collection { get; }
        public string Kind { get; }
        public ProjectItems ProjectItems { get; }
        public Properties Properties { get; }
        public string UniqueName { get; }
        public object Object { get; }
        public object ExtenderNames { get; }
        public string ExtenderCATID { get; }
        public string FullName { get; }
        public bool Saved { get; set; }
        public ConfigurationManager ConfigurationManager { get; }
        public Globals Globals { get; }
        public ProjectItem ParentProjectItem { get; }
        public CodeModel CodeModel { get; }
        public void SaveAs(string NewFileName) => throw new NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();
        public void Save(string FileName = "") => throw new NotImplementedException();
        public void Delete() => throw new NotImplementedException();
    }
}
