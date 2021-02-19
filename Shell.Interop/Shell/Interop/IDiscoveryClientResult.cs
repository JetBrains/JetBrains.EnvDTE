namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IDiscoveryClientResult
    {
        int GetFileName(out string pbstrFilename);

        int GetReferenceTypeName(out string pbstrReferenceTypeName);

        int GetUrl(out string pbstrUrl);
    }
}
