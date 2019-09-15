namespace EnvDTE
{
    public interface Document
    {
        DTE DTE { get; }
        string Kind { get; }
        Documents Collection { get; }
        Window ActiveWindow { get; }
        string FullName { get; }
        string Name { get; }
        string Path { get; }
        bool ReadOnly { get; set; }
        bool Saved { get; set; }
        Windows Windows { get; }
        ProjectItem ProjectItem { get; }
        object Selection { get; }
        object ExtenderNames { get; }
        string ExtenderCATID { get; }
        int IndentSize { get; }
        string Language { get; set; }
        int TabSize { get; }
        string Type { get; }
        void Activate();
        void Close(vsSaveChanges Save = vsSaveChanges.vsSaveChangesPrompt);
        Window NewWindow();
        bool Redo();
        bool Undo();
        vsSaveStatus Save(string FileName = "");
        object Object(string ModelKind = "");
        object get_Extender(string ExtenderName);
        void PrintOut();
        void ClearBookmarks();
        bool MarkText(string Pattern, int Flags = 0);
        bool ReplaceText(string FindText, string ReplaceText, int Flags = 0);
    }
}
