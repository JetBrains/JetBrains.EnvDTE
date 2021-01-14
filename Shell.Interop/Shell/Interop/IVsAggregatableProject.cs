using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsAggregatableProject
    {
        int SetInnerProject(object punkInner);

        int InitializeForOuter(
            string pszFilename,
            string pszLocation,
            string pszName,
            uint grfCreateFlags,
            ref Guid iidProject,
            out IntPtr ppvProject,
            out int pfCanceled);

        int OnAggregationComplete();

        int GetAggregateProjectTypeGuids(out string pbstrProjTypeGuids);
        int SetAggregateProjectTypeGuids(string lpstrProjTypeGuids);
    }
}
