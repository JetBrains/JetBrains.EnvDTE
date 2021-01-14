namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccControlNewSolution
    {
        int AddNewSolutionToSourceControl();

        int GetDisplayStringForAction( out string pbstrActionName);
    }
}
