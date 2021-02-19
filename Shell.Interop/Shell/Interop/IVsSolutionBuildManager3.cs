namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSolutionBuildManager3
    {
        int AdviseUpdateSolutionEvents3(
            IVsUpdateSolutionEvents3 pIVsUpdateSolutionEvents3,
            out uint pdwCookie);


        int UnadviseUpdateSolutionEvents3(uint dwCookie);


        int AreProjectsUpToDate(uint dwOptions);


        int HasHierarchyChangedSinceLastDTEE();


        int QueryBuildManagerBusyEx(out uint pdwBuildManagerOperation);
    }
}
