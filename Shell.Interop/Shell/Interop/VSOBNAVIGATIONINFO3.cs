using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public struct VSOBNAVIGATIONINFO3
    {
        public IntPtr pguidLib;
        public IntPtr pszLibName;
        public IntPtr pName;
        public uint dwCustom;
    }
}
