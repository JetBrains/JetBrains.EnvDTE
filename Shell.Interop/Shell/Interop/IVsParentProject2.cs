using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsParentProject2
    {
        int CreateNestedProject(
            uint itemidLoc,
            ref Guid rguidProjectType,
            string lpszMoniker,
            string lpszLocation,
            string lpszName,
            uint grfCreateFlags,
            ref Guid rguidProjectID,
            ref Guid iidProject,
            out IntPtr ppProject);

        int AddNestedSolution(uint itemidLoc, uint grfOpenOpts, string pszFilename);
    }
}
