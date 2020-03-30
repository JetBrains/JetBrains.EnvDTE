using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.EnvDTE.Client.Impl.ProjectModel;
using JetBrains.Rider.Model;
using Solution = EnvDTE.Solution;

namespace JetBrains.EnvDTE.Client.Impl
{
    [PublicAPI]
    public sealed class DteImplementation : DTE, DTE2
    {
        public DteImplementation([NotNull] DteProtocolModel dteProtocolModel)
        {
            DteProtocolModel = dteProtocolModel;
            Solution = new SolutionImplementation(this);
        }

        [NotNull]
        internal DteProtocolModel DteProtocolModel { get; }

        [NotNull]
        public DTE DTE => this;

        [NotNull]
        public string Name => DteProtocolModel.DTE_Name.Sync(Unit.Instance);

        [NotNull]
        public string FileName => DteProtocolModel.DTE_FileName.Sync(Unit.Instance);

        [NotNull]
        public string FullName => FileName;

        public vsIDEMode Mode => vsIDEMode.vsIDEModeDesign;

        [NotNull]
        public Solution Solution { get; } // Initialized in constructor

        public string CommandLineArguments => DteProtocolModel.DTE_CommandLineArgs.Sync(Unit.Instance);

        #region NotImplemented

        public string Version => throw new NotImplementedException();
        public object CommandBars => throw new NotImplementedException();
        public Windows Windows => throw new NotImplementedException();
        public Events Events => throw new NotImplementedException();
        public AddIns AddIns => throw new NotImplementedException();
        public Window MainWindow => throw new NotImplementedException();
        public Window ActiveWindow => throw new NotImplementedException();
        public void Quit() => throw new NotImplementedException();

        public vsDisplay DisplayMode
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Commands Commands => throw new NotImplementedException();
        public object GetObject(string Name) => throw new NotImplementedException();
        public Properties get_Properties(string Category, string Page) => throw new NotImplementedException();
        public SelectedItems SelectedItems => throw new NotImplementedException();
        public Window OpenFile(string ViewKind, string FileName) => throw new NotImplementedException();
        public bool get_IsOpenFile(string ViewKind, string FileName) => throw new NotImplementedException();
        public int LocaleID => throw new NotImplementedException();
        public WindowConfigurations WindowConfigurations => throw new NotImplementedException();
        public Documents Documents => throw new NotImplementedException();
        public Document ActiveDocument => throw new NotImplementedException();

        public void ExecuteCommand(string CommandName, string CommandArgs = "") =>
            throw new NotImplementedException();

        public Globals Globals => throw new NotImplementedException();
        public StatusBar StatusBar => throw new NotImplementedException();

        public bool UserControl
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ObjectExtenders ObjectExtenders => throw new NotImplementedException();
        public Find Find => throw new NotImplementedException();

        public wizardResult LaunchWizard(
            string VSZFile,
            ref object[] ContextParams
        ) => throw new NotImplementedException();

        public ItemOperations ItemOperations => throw new NotImplementedException();
        public UndoContext UndoContext => throw new NotImplementedException();
        public Macros Macros => throw new NotImplementedException();
        public object ActiveSolutionProjects => throw new NotImplementedException();
        public DTE MacrosIDE => throw new NotImplementedException();
        public string RegistryRoot => throw new NotImplementedException();
        public DTE Application => throw new NotImplementedException();
        public ContextAttributes ContextAttributes => throw new NotImplementedException();
        public SourceControl SourceControl => throw new NotImplementedException();

        public bool SuppressUI
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public global::EnvDTE.Debugger Debugger => throw new NotImplementedException();
        public string SatelliteDllPath(string Path, string Name) => throw new NotImplementedException();
        public string Edition => throw new NotImplementedException();
        public ToolWindows ToolWindows => throw new NotImplementedException();
        public uint GetThemeColor(vsThemeColors Element) => throw new NotImplementedException();

        #endregion
    }
}
