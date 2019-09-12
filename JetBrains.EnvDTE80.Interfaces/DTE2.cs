
using EnvDTE;


namespace EnvDTE80
{
	public interface DTE2 : _DTE
	{
		new string this[] { get; }
		new string FileName { get; }
		new string Version { get; }
		new object CommandBars { get; }
		new Windows Windows { get; }
		new Events Events { get; }
		new AddIns AddIns { get; }
		new Window MainWindow { get; }
		new Window ActiveWindow { get; }
		new vsDisplay DisplayMode { get; set; }
		new Solution Solution { get; }
		new Commands Commands { get; }
		new SelectedItems SelectedItems { get; }
		new string CommandLineArguments { get; }
		new DTE DTE { get; }
		new int LocaleID { get; }
		new WindowConfigurations WindowConfigurations { get; }
		new Documents Documents { get; }
		new Document ActiveDocument { get; }
		new Globals Globals { get; }
		new StatusBar StatusBar { get; }
		new string FullName { get; }
		new bool UserControl { get; set; }
		new ObjectExtenders ObjectExtenders { get; }
		new Find Find { get; }
		new vsIDEMode Mode { get; }
		new ItemOperations ItemOperations { get; }
		new UndoContext UndoContext { get; }
		new Macros Macros { get; }
		new object ActiveSolutionProjects { get; }
		new DTE MacrosIDE { get; }
		new string RegistryRoot { get; }
		new DTE Application { get; }
		new ContextAttributes ContextAttributes { get; }
		new SourceControl SourceControl { get; }
		new bool SuppressUI { get; set; }
		new Debugger Debugger { get; }
		new string Edition { get; }
		ToolWindows ToolWindows { get; }
		new void Quit();
		new object GetObject(string Name);
		new Properties get_Properties(string Category, string Page);
		new Window OpenFile(string ViewKind, string FileName);
		new bool get_IsOpenFile(string ViewKind, string FileName);
		new void ExecuteCommand(string CommandName, string CommandArgs = "");
		new wizardResult LaunchWizard(string VSZFile, ref object[] ContextParams);
		new string SatelliteDllPath(string Path, string Name);
		uint GetThemeColor(vsThemeColors Element);
	}
}
