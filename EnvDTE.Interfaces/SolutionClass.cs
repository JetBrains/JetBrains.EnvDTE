using System;
using System.Collections;

namespace EnvDTE
{
    public class SolutionClass : _Solution, Solution, IEnumerable
    {
        public virtual Project Item(object index) => throw new NotImplementedException();
        public virtual IEnumerator GetEnumerator() => throw new NotImplementedException();
        public virtual DTE DTE => throw new NotImplementedException();
        public virtual DTE Parent => throw new NotImplementedException();
        public virtual int Count => throw new NotImplementedException();
        public virtual string FileName => throw new NotImplementedException();
        public virtual void SaveAs(string FileName) => throw new NotImplementedException();

        public virtual Project AddFromTemplate(
            string FileName,
            string Destination,
            string ProjectName,
            bool Exclusive = false) => throw new NotImplementedException();

        public virtual Project AddFromFile(string FileName, bool Exclusive = false) =>
            throw new NotImplementedException();

        public virtual void Open(string FileName) => throw new NotImplementedException();
        public virtual void Close(bool SaveFirst = false) => throw new NotImplementedException();
        public virtual Properties Properties => throw new NotImplementedException();
        public virtual bool IsDirty { get; set; }
        public virtual void Remove(Project proj) => throw new NotImplementedException();
        public virtual string get_TemplatePath(string ProjectType) => throw new NotImplementedException();
        public virtual string FullName => throw new NotImplementedException();
        public virtual bool Saved { get; set; }
        public virtual Globals Globals => throw new NotImplementedException();
        public virtual AddIns AddIns => throw new NotImplementedException();
        public virtual object get_Extender(string ExtenderName) => throw new NotImplementedException();
        public virtual object ExtenderNames => throw new NotImplementedException();
        public virtual string ExtenderCATID => throw new NotImplementedException();
        public virtual bool IsOpen => throw new NotImplementedException();
        public virtual SolutionBuild SolutionBuild => throw new NotImplementedException();
        public virtual void Create(string Destination, string Name) => throw new NotImplementedException();
        public virtual Projects Projects => throw new NotImplementedException();
        public virtual ProjectItem FindProjectItem(string FileName) => throw new NotImplementedException();
        public virtual string ProjectItemsTemplatePath(string ProjectKind) => throw new NotImplementedException();
    }
}
