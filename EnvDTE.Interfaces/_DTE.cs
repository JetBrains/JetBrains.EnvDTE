namespace EnvDTE
{
    public interface _DTE
    {
        string Name { get; }
        string FileName { get; }
        string Version { get; }
        object CommandBars { get; }
        Windows Windows { get; }
        Events Events { get; }
        AddIns AddIns { get; }
        Window MainWindow { get; }
        Window ActiveWindow { get; }
        vsDisplay DisplayMode { get; set; }
        Solution Solution { get; }
        Commands Commands { get; }
        SelectedItems SelectedItems { get; }
        string CommandLineArguments { get; }
        DTE DTE { get; }
        int LocaleID { get; }
        WindowConfigurations WindowConfigurations { get; }
        Documents Documents { get; }
        Document ActiveDocument { get; }
        Globals Globals { get; }
        StatusBar StatusBar { get; }
        string FullName { get; }
        bool UserControl { get; set; }
        ObjectExtenders ObjectExtenders { get; }
        Find Find { get; }
        vsIDEMode Mode { get; }
        ItemOperations ItemOperations { get; }
        UndoContext UndoContext { get; }
        Macros Macros { get; }
        object ActiveSolutionProjects { get; }
        DTE MacrosIDE { get; }
        string RegistryRoot { get; }
        DTE Application { get; }
        ContextAttributes ContextAttributes { get; }
        SourceControl SourceControl { get; }
        bool SuppressUI { get; set; }
        Debugger Debugger { get; }
        string Edition { get; }
        void Quit();
        object GetObject(string Name);
        Properties get_Properties(string Category, string Page);
        Window OpenFile(string ViewKind, string FileName);
        bool get_IsOpenFile(string ViewKind, string FileName);
        void ExecuteCommand(string CommandName, string CommandArgs = "");
        wizardResult LaunchWizard(string VSZFile, ref object[] ContextParams);
        string SatelliteDllPath(string Path, string Name);
    }
}
