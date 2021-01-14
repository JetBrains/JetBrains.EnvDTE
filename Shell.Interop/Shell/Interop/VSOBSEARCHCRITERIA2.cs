namespace Microsoft.VisualStudio.Shell.Interop
{
    public struct VSOBSEARCHCRITERIA2
    {
        public string szName;
        public object eSrchType;
        public uint grfOptions;
        public uint dwCustom;
        public IVsNavInfo pIVsNavInfo;
    }
}
