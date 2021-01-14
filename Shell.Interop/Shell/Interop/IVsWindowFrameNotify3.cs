namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsWindowFrameNotify3
    {
        int OnShow(int fShow);


        int OnMove(int x, int y, int w, int h);


        int OnSize(int x, int y, int w, int h);


        int OnDockableChange(int fDockable, int x, int y, int w, int h);


        int OnClose(ref uint pgrfSaveOptions);
    }
}
