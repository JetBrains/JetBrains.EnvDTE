using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsCreateAggregateProject
    {
        int CreateAggregateProject(
            string pszProjectTypeGuids,
            string pszFilename,
            string pszLocation,
            string pszName,
            uint grfCreateFlags,
            ref Guid iidProject,
            out IntPtr ppvProject);
    }
}
