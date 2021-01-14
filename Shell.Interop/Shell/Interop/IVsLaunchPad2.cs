namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsLaunchPad2
    {
    int ExecCommandEx(
       string pszApplicationName,
       string pszCommandLine,
       string pszWorkingDir,
       uint lpf,
       object pOutputWindowPane,
       uint nTaskItemCategory,
       uint nTaskItemBitmap,
       string pszTaskListSubcategory,
       object pVsLaunchPadEvents,
       object pOutputParser,
       uint[] pdwProcessExitCode,
       string[] pbstrOutput);
    }
}
