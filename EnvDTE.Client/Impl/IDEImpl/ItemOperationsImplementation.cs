using System;
using System.IO;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.IDEImpl;

public class ItemOperationsImplementation([NotNull] DteImplementation dte) : ItemOperations
{
    public DTE DTE => dte;
    public DTE Parent => dte;

    public Window OpenFile(string fileName, string viewKind = Constants.vsViewKindPrimary)
    {
        dte.DteProtocolModel.ItemOperations_open_File.Sync(new(Path.GetFullPath(fileName), viewKind));
        // TODO: Implement Window
        return null;
    }

    public bool IsFileOpen(string fileName, string viewKind = Constants.vsViewKindAny) =>
        dte.DteProtocolModel.ItemOperations_isOpen_File.Sync(new(Path.GetFullPath(fileName), viewKind));

    #region NotImplemented

    public vsPromptResult PromptToSave => throw new NotImplementedException();

    public Window NewFile(string item = "General\\Text File", string name = "", string viewKind = Constants.vsViewKindPrimary) =>
        throw new NotImplementedException();

    public ProjectItem AddExistingItem(string fileName) =>
        throw new NotImplementedException();

    public ProjectItem AddNewItem(string item = "General\\Text File", string name = "") =>
        throw new NotImplementedException();

    public Window Navigate(string url = "", vsNavigateOptions options = vsNavigateOptions.vsNavigateOptionsDefault) =>
        throw new NotImplementedException();

    #endregion
}
