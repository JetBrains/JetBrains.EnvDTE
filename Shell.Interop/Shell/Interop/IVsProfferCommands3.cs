using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProfferCommands3
    {
        int AddNamedCommand(
            ref Guid pguidPackage,
            ref Guid pguidCmdGroup,
            string pszCmdNameCanonical,
            out uint pdwCmdId,
            string pszCmdNameLocalized,
            string pszBtnText,
            string pszCmdTooltip,
            string pszSatelliteDLL,
            uint dwBitmapResourceId,
            uint dwBitmapImageIndex,
            uint dwCmdFlagsDefault,
            uint cUIContexts,
            Guid[] rgguidUIContexts);

        int RemoveNamedCommand(string pszCmdNameCanonical);

        int RenameNamedCommand(
            string pszCmdNameCanonical,
            string pszCmdNameCanonicalNew,
            string pszCmdNameLocalizedNew);

        int AddCommandBarControl(
            string pszCmdNameCanonical,
            object pCmdBarParent,
            uint dwIndex,
            uint dwCmdType,
            out object ppCmdBarCtrl);

        int RemoveCommandBarControl(object pCmdBarCtrl);

        int AddCommandBar(
            string pszCmdBarName,
            uint dwType,
            object pCmdBarParent,
            uint dwIndex,
            out object ppCmdBar);

        int RemoveCommandBar(object pCmdBar);

        int FindCommandBar(
            object pToolbarSet,
            ref Guid pguidCmdGroup,
            uint dwMenuId,
            out object ppdispCmdBar);

        int AddNamedCommand2(
            ref Guid pguidPackage,
            ref Guid pguidCmdGroup,
            string pszCmdNameCanonical,
            out uint pdwCmdId,
            string pszCmdNameLocalized,
            string pszBtnText,
            string pszCmdTooltip,
            string pszSatelliteDLL,
            uint dwBitmapResourceId,
            uint dwBitmapImageIndex,
            uint dwCmdFlagsDefault,
            uint cUIContexts,
            Guid[] rgguidUIContexts,
            uint dwUIElementType);
    }
}
