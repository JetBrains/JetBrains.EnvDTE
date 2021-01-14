using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsObjectList2
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

        int GetCapabilities2(out uint pgrfCapabilities);

        int GetList2(
            uint index,
            uint ListType,
            uint flags,
            VSOBSEARCHCRITERIA2[] pobSrch,
            out IVsObjectList2 ppIVsObjectList2);

        int GetCategoryField2(uint index, int Category, out uint pfCatField);

        int GetExpandable3(uint index, uint ListTypeExcluded, out int pfExpandable);

        int GetNavigationInfo2(uint index, VSOBNAVIGATIONINFO3[] pobNav);

        int LocateNavigationInfo2(
            VSOBNAVIGATIONINFO3[] pobNav,
            VSOBNAVNAMEINFONODE2[] pobName,
            int fDontUpdate,
            out int pfMatchedName,
            out uint pIndex);

        int GetBrowseObject(uint index, out object ppdispBrowseObj);


        int GetUserContext(uint index, out object ppunkUserCtx);


        int ShowHelp(uint index);


        int GetSourceContext(uint index, IntPtr pszFilename, out uint pulLineNum);


        int CountSourceItems(uint index, out object ppHier, out uint pItemid, out uint pcItems);

        int GetMultipleSourceItems(uint index, uint grfGSI, uint cItems, object[] rgItemSel);

        int CanGoToSource(uint index, object SrcType, out int pfOK);

        int GoToSource(uint index, object SrcType);

        int GetContextMenu(
            uint index,
            out Guid pclsidActive,
            out int pnMenuId,
            out object ppCmdTrgtActive);

        int QueryDragDrop(uint index, object pDataObject, uint grfKeyState, ref uint pdwEffect);

        int DoDragDrop(uint index, object pDataObject, uint grfKeyState, ref uint pdwEffect);

        int CanRename(uint index, string pszNewName, out int pfOK);

        int DoRename(uint index, string pszNewName, uint grfFlags);

        int CanDelete(uint index, out int pfOK);

        int DoDelete(uint index, uint grfFlags);

        int FillDescription(uint index, uint grfOptions, object pobDesc);

        int FillDescription2(uint index, uint grfOptions, IVsObjectBrowserDescription3 pobDesc);

        int EnumClipboardFormats(
            uint index,
            uint grfFlags,
            uint celt,
            object[] rgcfFormats,
            uint[] pcActual);

        int GetClipboardFormat(uint index, uint grfFlags, object[] pFormatetc, object[] pMedium);

        int GetExtendedClipboardVariant(
            uint index,
            uint grfFlags,
            object[] pcfFormat,
            out object pvarFormat);

        int GetProperty(uint index, int propid, out object pvar);

        int GetNavInfo(uint index, out IVsNavInfo ppNavInfo);

        int GetNavInfoNode(uint index, out IVsNavInfoNode ppNavInfoNode);

        int LocateNavInfoNode(IVsNavInfoNode pNavInfoNode, out uint pulIndex);
    }
}
