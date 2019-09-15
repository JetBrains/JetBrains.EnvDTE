namespace EnvDTE
{
    public interface ItemOperations
    {
        DTE DTE { get; }
        DTE Parent { get; }
        vsPromptResult PromptToSave { get; }
        Window OpenFile(string FileName, string ViewKind = "{00000000-0000-0000-0000-000000000000}");

        Window NewFile(string Item = "General\\Text File", string Name = "",
            string ViewKind = "{00000000-0000-0000-0000-000000000000}");

        bool IsFileOpen(string FileName, string ViewKind = "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}");
        ProjectItem AddExistingItem(string FileName);
        ProjectItem AddNewItem(string Item = "General\\Text File", string Name = "");
        Window Navigate(string URL = "", vsNavigateOptions Options = vsNavigateOptions.vsNavigateOptionsDefault);
    }
}
