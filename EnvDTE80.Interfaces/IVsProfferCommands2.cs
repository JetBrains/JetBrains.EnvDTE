using System;
using EnvDTE;

namespace EnvDTE80
{
    public interface IVsProfferCommands2 : IVsProfferCommands
    {
        new void AddNamedCommand(
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
            ref Guid rgguidUIContexts);

        new void RemoveNamedCommand(string pszCmdNameCanonical);

        new void RenameNamedCommand(
            string pszCmdNameCanonical,
            string pszCmdNameCanonicalNew,
            string pszCmdNameLocalizedNew);

        new void AddCommandBarControl(
            string pszCmdNameCanonical,
            object pCmdBarParent,
            uint dwIndex,
            uint dwCmdType,
            out object ppCmdBarCtrl);

        new void RemoveCommandBarControl(object pCmdBarCtrl);

        new void AddCommandBar(
            string pszCmdBarName,
            vsCommandBarType dwType,
            object pCmdBarParent,
            uint dwIndex,
            out object ppCmdBar);

        new void RemoveCommandBar(object pCmdBar);
        new object FindCommandBar(IntPtr pToolbarSet, ref Guid pguidCmdGroup, uint dwMenuId);

        void AddNamedCommand2(
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
            ref Guid rgguidUIContexts,
            uint dwUIElementType);
    }
}
