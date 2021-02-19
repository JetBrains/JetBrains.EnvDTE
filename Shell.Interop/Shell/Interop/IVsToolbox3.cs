namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsToolbox3
    {
        int SetIDOfTab(string lpszTabName, string lpszTabID);


        int GetIDOfTab(string lpszTabName, out string pbstrTabID);


        int GetTabOfID(string lpszTabID, out string pbstrTabName);


        int GetGeneralTabID(out string pbstrTabID);


        int GetItemID(object pDO, out string pbstrID);


        int GetItemDisplayName(object pDO, out string pbstrName);


        int GetLastModifiedTime(SYSTEMTIME[] pst);
    }
}
