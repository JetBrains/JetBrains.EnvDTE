using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccOpenFromSourceControl
    {
        int OpenSolutionFromSourceControl(string pszSolutionStoreUrl);

        int AddProjectFromSourceControl(string pszProjectStoreUrl);

        int AddItemFromSourceControl(
            object pProject,
            uint itemidLoc,
            uint cFilesToAdd,
            string[] rgpszFilesToAdd,
            IntPtr hwndDlgOwner,
            uint grfEditorFlags,
            ref Guid rguidEditorType,
            string pszPhysicalView,
            ref Guid rguidLogicalView,
            object[] pResult);

        int GetNamespaceExtensionInformation(
            int vsofsdDlg,
            out string pbstrNamespaceGUID,
            out string pbstrTrayDisplayName,
            out string pbstrProtocolPrefix);
    }
}
