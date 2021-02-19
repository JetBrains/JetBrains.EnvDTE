namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsAsynchOpenFromScc
    {
        int LoadProjectAsynchronously(string lpszProjectPath, out int pReturnValue);

        int LoadProject(string lpszProjectPath);
        int IsLoadingContent(object pHierarchy, out int pfIsLoading);
    }
}
