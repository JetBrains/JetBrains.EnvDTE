using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE;
using EnvDTE100;
using EnvDTE80;
using EnvDTE90;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl
{
    public sealed class SolutionImplementation([NotNull] DteImplementation dte) : Solution, Solution4
    {
        [CanBeNull] private SolutionBuildImplementation _solutionBuild;
        [CanBeNull] private SolutionPropertiesImplementation _solutionProperties;

        [NotNull, ItemNotNull]
        private List<ProjectItemModel> ProjectModels => dte.DteProtocolModel.Solution_get_Projects.Sync(Unit.Instance);

        public DTE DTE => dte;
        public DTE Parent => dte;
        public string FileName => dte.DteProtocolModel.Solution_FileName.Sync(Unit.Instance);
        public string FullName => FileName;
        public int Count => dte.DteProtocolModel.Solution_Count.Sync(Unit.Instance);
        public Projects Projects => new ProjectsImplementation(dte, ProjectModels);

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
            return response is null ? null : new ProjectItemImplementation(dte, response.ProjectItem,
                ProjectImplementation.GetFromPath(dte, response.ProjectPath));
        }

        #region NotImplemented

        public void SaveAs(string FileName) => throw new NotImplementedException();

        public Project AddFromTemplate(
            string FileName,
            string Destination,
            string ProjectName,
            bool Exclusive = false
        ) => throw new NotImplementedException();

        public Project AddFromFile(string FileName, bool Exclusive = false) =>
            throw new NotImplementedException();

        public void Open(string FileName) => throw new NotImplementedException();
        public void Close(bool SaveFirst = false) => throw new NotImplementedException();
        public bool IsDirty { get; set; }
        public void Remove(Project proj) => throw new NotImplementedException();
        public string get_TemplatePath(string ProjectType) => throw new NotImplementedException();
        public bool Saved { get; set; }
        public Globals Globals => throw new NotImplementedException();
        public AddIns AddIns => throw new NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public bool IsOpen => throw new NotImplementedException();
        public void Create(string Destination, string Name) => throw new NotImplementedException();
        public string ProjectItemsTemplatePath(string ProjectKind) => throw new NotImplementedException();
        Project Solution2.AddSolutionFolder(string Name) => throw new NotImplementedException();

        string Solution2.GetProjectTemplate(string TemplateName, string Language) =>
            throw new NotImplementedException();

        string Solution2.GetProjectItemTemplate(string TemplateName, string Language) =>
            throw new NotImplementedException();

        Project Solution3.AddSolutionFolder(string Name) => throw new NotImplementedException();

        string Solution3.GetProjectTemplate(string TemplateName, string Language) =>
            throw new NotImplementedException();

        string Solution3.GetProjectItemTemplate(string TemplateName, string Language) =>
            throw new NotImplementedException();

        Templates Solution3.GetProjectItemTemplates(string Language, string CustomDataSignature) =>
            throw new NotImplementedException();

        Project Solution4.AddSolutionFolder(string Name) => throw new NotImplementedException();

        string Solution4.GetProjectTemplate(string TemplateName, string Language) =>
            throw new NotImplementedException();

        string Solution4.GetProjectItemTemplate(string TemplateName, string Language) =>
            throw new NotImplementedException();

        Templates Solution4.GetProjectItemTemplates(string Language, string CustomDataSignature) =>
            throw new NotImplementedException();

        public Project AddFromTemplateEx(
            string FileName,
            string Destination,
            string ProjectName,
            string SolutionName,
            bool Exclusive = true,
            uint Options = 0
        ) => throw new NotImplementedException();

        #endregion
    }
}
