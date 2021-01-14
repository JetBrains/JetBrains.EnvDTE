namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSettingsErrorInformation
    {
        int GetCompletionStatus(out uint pdwCompletionStatus);

        int GetErrorCount(out int pnErrors);

        int GetErrorInfo(int nErrorIndex, out uint pdwErrorType, out string pbstrError);
    }
}
