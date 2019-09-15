using System.Collections;

namespace EnvDTE
{
    public class SolutionClass : _Solution, Solution, IEnumerable
    {
        public extern SolutionClass();
        public virtual extern Project Item(object index);
        public virtual extern IEnumerator GetEnumerator();
        public virtual extern DTE DTE { get; }
        public virtual extern DTE Parent { get; }
        public virtual extern int Count { get; }
        public virtual extern string FileName { get; }
        public virtual extern void SaveAs(string FileName);

        public virtual extern Project AddFromTemplate(
            string FileName,
            string Destination,
            string ProjectName,
            bool Exclusive = false);

        public virtual extern Project AddFromFile(string FileName, bool Exclusive = false);
        public virtual extern void Open(string FileName);
        public virtual extern void Close(bool SaveFirst = false);
        public virtual extern Properties Properties { get; }
        public virtual extern bool IsDirty { get; set; }
        public virtual extern void Remove(Project proj);
        public virtual extern string get_TemplatePath(string ProjectType);
        public virtual extern string FullName { get; }
        public virtual extern bool Saved { get; set; }
        public virtual extern Globals Globals { get; }
        public virtual extern AddIns AddIns { get; }
        public virtual extern object get_Extender(string ExtenderName);
        public virtual extern object ExtenderNames { get; }
        public virtual extern string ExtenderCATID { get; }
        public virtual extern bool IsOpen { get; }
        public virtual extern SolutionBuild SolutionBuild { get; }
        public virtual extern void Create(string Destination, string Name);
        public virtual extern Projects Projects { get; }
        public virtual extern ProjectItem FindProjectItem(string FileName);
        public virtual extern string ProjectItemsTemplatePath(string ProjectKind);
    }
}
