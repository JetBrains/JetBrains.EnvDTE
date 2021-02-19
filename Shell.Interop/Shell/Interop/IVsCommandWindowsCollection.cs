namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsCommandWindowsCollection
    {
        int Create(uint mode, uint dwToolWindowId, int fShow, out uint puCookie);

        int OpenExistingOrCreateNewCommandWindow(
            uint mode,
            int fShow,
            out uint puCookie);

        int GetCommandWindowFromCookie(
            uint uCookie,  out object ppunkCmdWindow);

        int GetCommandWindowFromMode(
            uint mode,  out object ppunkCmdWindow);

        int SetRunningCommandWindowCommand(
            uint uCookie,
            int fCmdWin);

        int IsOutputWaiting(
            uint uCookie);

        int Close(
            uint uCookie);

        int CloseAllCommandWindows();
    }
}
