namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsPreviewChangesList
    {
        int GetFlags(out uint pFlags);

        int GetItemCount(out uint pCount);

        int GetExpandedList(uint index, out int pfCanRecurse, out object pptlNode);

        int LocateExpandedList(object ExpandedList, out uint iIndex);


        int OnClose(object[] ptca);

        int GetText(uint index, object tto, out string ppszText);

        int GetTipText(uint index, object eTipType, out string ppszText);

        int GetExpandable(uint index, out int pfExpandable);

        int GetDisplayData(uint index, object[] pData);

        int UpdateCounter(out uint pCurUpdate, out uint pgrfChanges);

        int GetListChanges(ref uint pcChanges, object[] prgListChanges);

        int ToggleState(uint index, out uint ptscr);

        int OnRequestSource(uint index, object pIUnknownTextView);
    }
}
