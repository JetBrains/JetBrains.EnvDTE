using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsMonitorSelection2
    {
        int GetElementID(ref Guid rguidElement, out uint pElementId);

        int GetEmptySelectionContext(out object ppEmptySelCtxt);
    }
}
