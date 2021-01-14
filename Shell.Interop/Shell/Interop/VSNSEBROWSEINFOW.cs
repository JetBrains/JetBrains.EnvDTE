namespace Microsoft.VisualStudio.Shell.Interop
{
    public struct VSNSEBROWSEINFOW
    {
        public uint lStructSize;
        public string pszNamespaceGUID;
        public string pszTrayDisplayName;
        public string pszProtocolPrefix;
        public int fOnlyShowNSEInTray;
    }
}
