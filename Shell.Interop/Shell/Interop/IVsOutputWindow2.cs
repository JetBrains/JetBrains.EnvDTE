using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsOutputWindow2
    {
        int GetActivePaneGUID(out Guid pguidPane);
    }
}
