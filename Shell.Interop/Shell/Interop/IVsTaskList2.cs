using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsTaskList2
    {
        int GetSelectionCount(out int pnItems);


        int GetCaretPos(out object ppItem);


        int EnumSelectedItems(out object ppEnum);


        int SelectItems(int nItems, object[] pItems, uint tsfSelType, uint tsspScrollPos);


        int BeginTaskEdit(object pItem, int iFocusField);


        int GetActiveProvider(out object ppProvider);


        int SetActiveProvider(ref Guid rguidProvider);


        int RefreshOrAddTasks(uint vsProviderCookie, int nTasks, object[] prgTasks);


        int RemoveTasks(uint vsProviderCookie, int nTasks, object[] prgTasks);


        int RefreshAllProviders();
    }
}
