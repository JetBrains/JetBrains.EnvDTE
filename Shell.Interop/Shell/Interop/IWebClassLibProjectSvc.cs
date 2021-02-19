namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IWebClassLibProjectSvc
    {
        int CreateClassLibProject(
            object pHier,
            string pszRootPathOrUrl,
            uint dwFlags,
            string pszOptionalVDir,
            out IWebClassLibProject ppClassLibProject);
    }
}
