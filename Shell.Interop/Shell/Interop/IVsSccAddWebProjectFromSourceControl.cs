namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccAddWebProjectFromSourceControl
    {
        int IsAddWebProjectSupported(out bool pfResult);

        int BrowseForServerLocation(
            out string pbstrLocationDescription,
            out string pbstrLocalPath,
            out string pbstrDatabasePath,
            out string pbstrAuxiliarPath,
            out string pbstrProviderName);

        int AddWebProjectFromSourceControl(
            string bstrLocalPath,
            string bstrDatabasePath,
            string bstrAuxiliarPath,
            string bstrProviderName,
            string bstrDebuggingPath);
    }
}
