using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsOpenProjectOrSolutionDlg
    {
        int OpenProjectOrSolutionViaDlg(
            uint grfProjSlnDlgFlags,
            string pwzStartDirectory,
            string pwzDialogTitle,
            ref Guid rguidProjectType);
    }
}
