namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IDiscoveryResult2
    {
        int DownloadServiceDocument(
            string bstrDestinationPath,
            string bstrDiscomapFileName,
            out IDiscoveryClientResultCollection ppIDiscoveryClientResultCollection);
    }
}
