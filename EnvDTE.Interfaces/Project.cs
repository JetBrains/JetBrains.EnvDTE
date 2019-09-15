namespace EnvDTE
{
    public interface Project
    {
        string Name { get; set; }
        string FileName { get; }
        bool IsDirty { get; set; }
        Projects Collection { get; }
        DTE DTE { get; }
        string Kind { get; }
        ProjectItems ProjectItems { get; }
        Properties Properties { get; }
        string UniqueName { get; }
        object Object { get; }
        object ExtenderNames { get; }
        string ExtenderCATID { get; }
        string FullName { get; }
        bool Saved { get; set; }
        ConfigurationManager ConfigurationManager { get; }
        Globals Globals { get; }
        ProjectItem ParentProjectItem { get; }
        CodeModel CodeModel { get; }
        void SaveAs(string NewFileName);
        object get_Extender(string ExtenderName);
        void Save(string FileName = "");
        void Delete();
    }
}
