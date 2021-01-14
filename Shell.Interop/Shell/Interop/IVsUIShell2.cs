using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsUIShell2
    {
        int GetOpenFileNameViaDlgEx(object[] pOpenFileName, string pszHelpTopic);


        int GetSaveFileNameViaDlgEx(object[] pSaveFileName, string pszHelpTopic);


        int GetDirectoryViaBrowseDlgEx(
            object[] pBrowse,
            string pszHelpTopic,
            string pszOpenButtonLabel,
            string pszCeilingDir,
            VSNSEBROWSEINFOW[] pNSEBrowseInfo);


        int SaveItemsViaDlg(uint cItems, VSSAVETREEITEM[] rgSaveItems);


        int GetVSSysColorEx(int dwSysColIndex, out uint pdwRGBval);


        int CreateGradient(uint GRADIENTTYPE, out IVsGradient pGradient);


        int GetVSCursor(uint cursor, out IntPtr phIcon);


        int IsAutoRecoverSavingCheckpoints(out int pfARSaving);


        int VsDialogBoxParam(uint hinst, uint dwId, uint lpDialogFunc, int lp);


        int CreateIconImageButton(
            IntPtr hwnd,
            IntPtr hicon,
            uint bwiPos,
            out IVsImageButton ppImageButton);


        int CreateGlyphImageButton(
            IntPtr hwnd,
            ushort chGlyph,
            int xShift,
            int yShift,
            uint bwiPos,
            out IVsImageButton ppImageButton);
    }
}
