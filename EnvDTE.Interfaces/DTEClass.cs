using System;

namespace EnvDTE
{
    public class DTEClass : _DTE, DTE
    {
        public virtual string Name => throw new NotImplementedException();
        public virtual string FileName => throw new NotImplementedException();
        public virtual string Version => throw new NotImplementedException();
        public virtual object CommandBars => throw new NotImplementedException();
        public virtual Windows Windows => throw new NotImplementedException();
        public virtual Events Events => throw new NotImplementedException();
        public virtual AddIns AddIns => throw new NotImplementedException();
        public virtual Window MainWindow => throw new NotImplementedException();
        public virtual Window ActiveWindow => throw new NotImplementedException();
        public virtual void Quit() => throw new NotImplementedException();

        public virtual vsDisplay DisplayMode
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public virtual Solution Solution => throw new NotImplementedException();
        public virtual Commands Commands => throw new NotImplementedException();
        public virtual object GetObject(string Name) => throw new NotImplementedException();
        public virtual Properties get_Properties(string Category, string Page) => throw new NotImplementedException();
        public virtual SelectedItems SelectedItems => throw new NotImplementedException();
        public virtual string CommandLineArguments => throw new NotImplementedException();
        public virtual Window OpenFile(string ViewKind, string FileName) => throw new NotImplementedException();
        public virtual bool get_IsOpenFile(string ViewKind, string FileName) => throw new NotImplementedException();
        public virtual DTE DTE => throw new NotImplementedException();
        public virtual int LocaleID => throw new NotImplementedException();
        public virtual WindowConfigurations WindowConfigurations => throw new NotImplementedException();
        public virtual Documents Documents => throw new NotImplementedException();
        public virtual Document ActiveDocument => throw new NotImplementedException();

        public virtual void ExecuteCommand(string CommandName, string CommandArgs = "") =>
            throw new NotImplementedException();

        public virtual Globals Globals => throw new NotImplementedException();
        public virtual StatusBar StatusBar => throw new NotImplementedException();
        public virtual string FullName => throw new NotImplementedException();

        public virtual bool UserControl
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public virtual ObjectExtenders ObjectExtenders => throw new NotImplementedException();
        public virtual Find Find => throw new NotImplementedException();
        public virtual vsIDEMode Mode => throw new NotImplementedException();

        public virtual wizardResult LaunchWizard(
            string VSZFile,
            ref object[] ContextParams) => throw new NotImplementedException();

        public virtual ItemOperations ItemOperations => throw new NotImplementedException();
        public virtual UndoContext UndoContext => throw new NotImplementedException();
        public virtual Macros Macros => throw new NotImplementedException();
        public virtual object ActiveSolutionProjects => throw new NotImplementedException();
        public virtual DTE MacrosIDE => throw new NotImplementedException();
        public virtual string RegistryRoot => throw new NotImplementedException();
        public virtual DTE Application => throw new NotImplementedException();
        public virtual ContextAttributes ContextAttributes => throw new NotImplementedException();
        public virtual SourceControl SourceControl => throw new NotImplementedException();

        public virtual bool SuppressUI
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public virtual Debugger Debugger => throw new NotImplementedException();
        public virtual string SatelliteDllPath(string Path, string Name) => throw new NotImplementedException();
        public virtual string Edition => throw new NotImplementedException();
    }
}
