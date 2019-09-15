using System.Collections;

namespace EnvDTE
{
    public interface _Solution : IEnumerable
    {
        DTE DTE { get; }
        DTE Parent { get; }
        int Count { get; }
        string FileName { get; }
        Properties Properties { get; }
        bool IsDirty { get; set; }
        string FullName { get; }
        bool Saved { get; set; }
        Globals Globals { get; }
        AddIns AddIns { get; }
        object ExtenderNames { get; }
        string ExtenderCATID { get; }
        bool IsOpen { get; }
        SolutionBuild SolutionBuild { get; }
        Projects Projects { get; }
        Project Item(object index);
        new IEnumerator GetEnumerator();
        void SaveAs(string FileName);

        Project AddFromTemplate(
            string FileName,
            string Destination,
            string ProjectName,
            bool Exclusive = false);

        Project AddFromFile(string FileName, bool Exclusive = false);
        void Open(string FileName);
        void Close(bool SaveFirst = false);
        void Remove(Project proj);
        string get_TemplatePath(string ProjectType);
        object get_Extender(string ExtenderName);
        void Create(string Destination, string Name);
        ProjectItem FindProjectItem(string FileName);
        string ProjectItemsTemplatePath(string ProjectKind);
    }
}
