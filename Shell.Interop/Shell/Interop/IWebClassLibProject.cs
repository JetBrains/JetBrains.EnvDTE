namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IWebClassLibProject
    {
        int UpdateAnchoredPath(string pszNewRootPath, string pszOptionalVDir);

        int CloseProject();

        int UnloadAppDomain(int bWaitForReset);
    }
}
