namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsThreadedWaitDialog
    {
        int StartWaitDialog(
            string bstrWaitCaption,
            string bstrWaitMessage,
            string bstrIfTruncateAppend,
            uint dwFlags,
            object varStatusBmpAnim,
            string bstrStatusBarText);


        int EndWaitDialog(ref int pfCancelled);


        int GiveTimeSlice(
            string bstrUpdatedWaitMessage,
            string bstrIfTruncateAppend,
            int fDisableCancel,
            out int pfCancelled);
    }
}
