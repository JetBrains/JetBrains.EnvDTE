namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccProjectEnlistmentFactory
    {
        int GetDefaultEnlistment(
            string lpszProjectPath,
            out string pbstrDefaultEnlistment,
            out string pbstrDefaultEnlistmentUNC);

        int GetEnlistmentFactoryOptions(out uint pvscefoOptions);

        int ValidateEnlistmentEdit(
            int fQuick,
            string lpszProjectPath,
            string lpszChosenEnlistment,
            out string pbstrChosenEnlistmentUNC,
            out int pfValidEnlistment);

        int BrowseEnlistment(
            string lpszProjectPath,
            string lpszInitialEnlistment,
            out string pbstrChosenEnlistment,
            out string pbstrChosenEnlistmentUNC);

        int OnBeforeEnlistmentCreate(
            string lpszProjectPath,
            string lpszEnlistment,
            string lpszEnlistmentUNC);

        int OnAfterEnlistmentCreate(
            string lpszProjectPath,
            string lpszEnlistment,
            string lpszEnlistmentUNC);
    }
}
