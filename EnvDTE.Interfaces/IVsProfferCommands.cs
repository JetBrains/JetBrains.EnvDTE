using System;

namespace EnvDTE
{
    public interface IVsProfferCommands
    {
        void AddNamedCommand(
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

        void RemoveNamedCommand(string pszCmdNameCanonical);

        void RenameNamedCommand(
            string pszCmdNameCanonical,
            string pszCmdNameCanonicalNew,
            string pszCmdNameLocalizedNew);

        void AddCommandBarControl(
            string pszCmdNameCanonical,
            object pCmdBarParent,
            uint dwIndex,
            uint dwCmdType,
            out object ppCmdBarCtrl);

        void RemoveCommandBarControl(object pCmdBarCtrl);

        void AddCommandBar(
            string pszCmdBarName,
            vsCommandBarType dwType,
            object pCmdBarParent,
            uint dwIndex,
            out object ppCmdBar);

        void RemoveCommandBar(object pCmdBar);
        object FindCommandBar(IntPtr pToolbarSet, ref Guid pguidCmdGroup, uint dwMenuId);
    }
}
