using System;
using System.IO;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.IDE;

public class ItemOperationsImplementation(
    [NotNull] DteImplementation dte) : ItemOperations
{
    public DTE DTE => dte;
    public DTE Parent => dte;

    public Window OpenFile(string fileName, string viewKind = "{00000000-0000-0000-0000-000000000000}")
    {
        dte.DteProtocolModel.ItemOperations_open_File.Sync(new(Path.GetFullPath(fileName), viewKind));
        // TODO: Implement Window
        return null;
    }

    public bool IsFileOpen(string fileName, string viewKind = "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}") =>
        dte.DteProtocolModel.ItemOperations_isOpen_File.Sync(new(Path.GetFullPath(fileName), viewKind));

    #region NotImplemented

    public vsPromptResult PromptToSave { get; }

    public Window NewFile(string Item = "General\\Text File", string Name = "",
        string ViewKind = "{00000000-0000-0000-0000-000000000000}") =>
        throw new NotImplementedException();

    public ProjectItem AddExistingItem(string FileName) =>
        throw new NotImplementedException();

    public ProjectItem AddNewItem(string Item = "General\\Text File", string Name = "") =>
        throw new NotImplementedException();

    public Window Navigate(string URL = "", vsNavigateOptions Options = vsNavigateOptions.vsNavigateOptionsDefault) =>
        throw new NotImplementedException();

    #endregion
}
