using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSmartOpenScope
    {
        int OpenScope(string wszScope, uint dwOpenFlags, ref Guid riid, out object ppIUnk);
    }
}
