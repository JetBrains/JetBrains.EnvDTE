using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EnvDTE
{
	public class DTEClass : _DTE, DTE
	{
		public extern DTEClass();
		public virtual extern string Name { get; }
		public virtual extern string FileName { get; }
		public virtual extern string Version { get; }
		public virtual extern object CommandBars { get; }
		public virtual extern Windows Windows { get; }
		public virtual extern Events Events { get; }
		public virtual extern AddIns AddIns { get; }
		public virtual extern Window MainWindow { get; }
		public virtual extern Window ActiveWindow { get; }
		public virtual extern void Quit();
		public virtual extern vsDisplay DisplayMode { get; set; }
		public virtual extern Solution Solution { get; }
		public virtual extern Commands Commands { get; }
		public virtual extern object GetObject(string Name);
		public virtual extern Properties get_Properties(string Category, string Page);
		public virtual extern SelectedItems SelectedItems { get; }
		public virtual extern string CommandLineArguments { get; }
		public virtual extern Window OpenFile(string ViewKind, string FileName);
		public virtual extern bool get_IsOpenFile(string ViewKind, string FileName);
		public virtual extern DTE DTE { get; }
		public virtual extern int LocaleID { get; }
		public virtual extern WindowConfigurations WindowConfigurations { get; }
		public virtual extern Documents Documents { get; }
		public virtual extern Document ActiveDocument { get; }
		public virtual extern void ExecuteCommand(string CommandName, string CommandArgs = "");
		public virtual extern Globals Globals { get; }
		public virtual extern StatusBar StatusBar { get; }
		public virtual extern string FullName { get; }
		public virtual extern bool UserControl { get; set; }
		public virtual extern ObjectExtenders ObjectExtenders { get; }
		public virtual extern Find Find { get; }
		public virtual extern vsIDEMode Mode { get; }

		public virtual extern wizardResult LaunchWizard(
			string VSZFile,
			ref object[] ContextParams);

		public virtual extern ItemOperations ItemOperations { get; }
		public virtual extern UndoContext UndoContext { get; }
		public virtual extern Macros Macros { get; }
		public virtual extern object ActiveSolutionProjects { get; }
		public virtual extern DTE MacrosIDE { get; }
		public virtual extern string RegistryRoot { get; }
		public virtual extern DTE Application { get; }
		public virtual extern ContextAttributes ContextAttributes { get; }
		public virtual extern SourceControl SourceControl { get; }
		public virtual extern bool SuppressUI { get; set; }
		public virtual extern Debugger Debugger { get; }
		public virtual extern string SatelliteDllPath(string Path, string Name);
		public virtual extern string Edition { get; }
	}
}
