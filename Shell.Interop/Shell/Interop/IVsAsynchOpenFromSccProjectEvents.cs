namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsAsynchOpenFromSccProjectEvents
    {
        int OnFilesDownloaded(int cFiles, string[] rgpszFullPaths);

        int OnLoadComplete();

        int OnLoadFailed();
    }
}
