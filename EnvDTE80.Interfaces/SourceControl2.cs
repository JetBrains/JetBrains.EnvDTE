using EnvDTE;

namespace EnvDTE80
{
    public interface SourceControl2 : SourceControl
    {
        new DTE DTE { get; }
        new DTE Parent { get; }
        new bool IsItemUnderSCC(string ItemName);
        new bool IsItemCheckedOut(string ItemName);
        new bool CheckOutItem(string ItemName);
        new bool CheckOutItems(ref object[] ItemNames);
        new void ExcludeItem(string ProjectFile, string ItemName);
        new void ExcludeItems(string ProjectFile, ref object[] ItemNames);
        SourceControlBindings GetBindings(string ItemPath);
        bool CheckOutItem2(string ItemName, vsSourceControlCheckOutOptions Flags);
        bool CheckOutItems2(ref object[] ItemNames, vsSourceControlCheckOutOptions Flags);
        void UndoExcludeItem(string ProjectFile, string ItemName);
        void UndoExcludeItems(string ProjectFile, ref object[] ItemNames);
    }
}
