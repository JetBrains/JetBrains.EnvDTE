namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccVirtualFolders
    {
        int GetVirtualFolders(uint itemid, object[] pCaStringsOut);

        int IsItemChildOfVirtualFolder(string pszItemName, out bool pfResult);
    }
}
