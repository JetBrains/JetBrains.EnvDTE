using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsShell2
    {
        int LoadPackageStringWithLCID(
            ref Guid guidPackage,
            uint resid,
            uint lcid,
            out string pbstrOut);
    }
}
