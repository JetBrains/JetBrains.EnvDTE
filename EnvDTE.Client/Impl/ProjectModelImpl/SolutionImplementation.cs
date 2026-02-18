using System;
using System.Collections;
using EnvDTE;
using EnvDTE100;
using EnvDTE80;
using EnvDTE90;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;
using JetBrains.EnvDTE.Client.Util;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl
{
    public sealed class SolutionImplementation([NotNull] DteImplementation dte) : Solution, Solution4
    {
        [CanBeNull] private SolutionBuildImplementation _solutionBuild;
        [CanBeNull] private SolutionPropertiesImplementation _solutionProperties;

        public DTE DTE => dte;
        public DTE Parent => dte;
        public string FileName => dte.DteProtocolModel.Solution_FileName.Sync(Unit.Instance);
        public string FullName => FileName;
        public int Count => dte.DteProtocolModel.Solution_Count.Sync(Unit.Instance);
        public Projects Projects => new ProjectsImplementation(dte);

        public Properties Properties
        {
            get
            {
                _solutionProperties ??= new SolutionPropertiesImplementation(dte, this);
                return _solutionProperties;
            }
        }

        public SolutionBuild SolutionBuild
        {
            get
            {
                _solutionBuild ??= new SolutionBuildImplementation(dte, this);
                return _solutionBuild;
            }
        }

        public IEnumerator GetEnumerator() => Projects.GetEnumerator();

        public Project Item(object index)
        {
            var i = ImplementationUtil.GetValidIndexOrThrow(index);
            var item = dte.DteProtocolModel.Solution_Item.Sync(i);
            return item is null
                ? throw new ArgumentOutOfRangeException()
                : new ProjectImplementation(dte, item);
        }

        public ProjectItem FindProjectItem(string fileName)
        {
            var response = dte.DteProtocolModel.Solution_find_ProjectItem.Sync(fileName);
            // `SolutionFolderProjectItem` cannot be queried using this method
            return response is null
                ? null
                : new ProjectItemImplementation(dte, response.ProjectItem, dte.GetProject(response.Project));
        }

        #region NotImplemented

        public void SaveAs(string fileName) => throw new NotImplementedException();

        public Project AddFromTemplate(
            string fileName,
            string destination,
            string projectName,
            bool exclusive = false
        ) => throw new NotImplementedException();

        public Project AddFromFile(string fileName, bool exclusive = false) =>
            throw new NotImplementedException();

        public void Open(string fileName) => throw new NotImplementedException();
        public void Close(bool saveFirst = false) => throw new NotImplementedException();
        public bool IsDirty { get; set; }
        public void Remove(Project proj) => throw new NotImplementedException();
        public string get_TemplatePath(string projectType) => throw new NotImplementedException();
        public bool Saved { get; set; }
        public Globals Globals => throw new NotImplementedException();
        public AddIns AddIns => throw new NotImplementedException();
        public object get_Extender(string extenderName) => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public bool IsOpen => throw new NotImplementedException();
        public void Create(string destination, string name) => throw new NotImplementedException();
        public string ProjectItemsTemplatePath(string projectKind) => throw new NotImplementedException();
        Project Solution2.AddSolutionFolder(string name) => throw new NotImplementedException();

        string Solution2.GetProjectTemplate(string templateName, string language) =>
            throw new NotImplementedException();

        string Solution2.GetProjectItemTemplate(string templateName, string language) =>
            throw new NotImplementedException();

        Project Solution3.AddSolutionFolder(string name) => throw new NotImplementedException();

        string Solution3.GetProjectTemplate(string templateName, string language) =>
            throw new NotImplementedException();

        string Solution3.GetProjectItemTemplate(string templateName, string language) =>
            throw new NotImplementedException();

        Templates Solution3.GetProjectItemTemplates(string language, string customDataSignature) =>
            throw new NotImplementedException();

        Project Solution4.AddSolutionFolder(string name) => throw new NotImplementedException();

        string Solution4.GetProjectTemplate(string templateName, string language) =>
            throw new NotImplementedException();

        string Solution4.GetProjectItemTemplate(string templateName, string language) =>
            throw new NotImplementedException();

        Templates Solution4.GetProjectItemTemplates(string language, string customDataSignature) =>
            throw new NotImplementedException();

        public Project AddFromTemplateEx(
            string fileName,
            string destination,
            string projectName,
            string solutionName,
            bool exclusive = true,
            uint options = 0
        ) => throw new NotImplementedException();

        #endregion
    }
}
