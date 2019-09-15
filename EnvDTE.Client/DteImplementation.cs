using System;
using EnvDTE;

namespace JetBrains.EnvDTE
{
    public sealed class DteImplementation : DTE
    {
        public string Name => "JetBrains Rider";
        public string FileName { get; }
        public string Version { get; }
        public object CommandBars { get; }
        public Windows Windows { get; }
        public Events Events { get; }
        public AddIns AddIns { get; }
        public Window MainWindow { get; }
        public Window ActiveWindow { get; }
        public vsDisplay DisplayMode { get; set; }
        public Solution Solution { get; }
        public Commands Commands { get; }
        public SelectedItems SelectedItems { get; }
        public string CommandLineArguments { get; }
        public DTE DTE { get; }
        public int LocaleID { get; }
        public WindowConfigurations WindowConfigurations { get; }
        public Documents Documents { get; }
        public Document ActiveDocument { get; }
        public Globals Globals { get; }
        public StatusBar StatusBar { get; }
        public string FullName { get; }
        public bool UserControl { get; set; }
        public ObjectExtenders ObjectExtenders { get; }
        public Find Find { get; }
        public vsIDEMode Mode { get; }
        public ItemOperations ItemOperations { get; }
        public UndoContext UndoContext { get; }
        public Macros Macros { get; }
        public object ActiveSolutionProjects { get; }
        public DTE MacrosIDE { get; }
        public string RegistryRoot { get; }
        public DTE Application { get; }
        public ContextAttributes ContextAttributes { get; }
        public SourceControl SourceControl { get; }
        public bool SuppressUI { get; set; }
        public Debugger Debugger { get; }
        public string Edition { get; }
        public void Quit() => throw new NotImplementedException();
        public object GetObject(string Name) => throw new NotImplementedException();
        public Window OpenFile(string ViewKind, string FileName) => throw new NotImplementedException();

        public void ExecuteCommand(string CommandName, string CommandArgs = "")
        {
            throw new NotImplementedException();
        }

        public wizardResult LaunchWizard(string VSZFile, ref object[] ContextParams) =>
            throw new NotImplementedException();

        public string SatelliteDllPath(string Path, string Name) => throw new NotImplementedException();
        public Properties get_Properties(string Category, string Page) => throw new NotImplementedException();
        public bool get_IsOpenFile(string ViewKind, string FileName) => throw new NotImplementedException();
    }
}
