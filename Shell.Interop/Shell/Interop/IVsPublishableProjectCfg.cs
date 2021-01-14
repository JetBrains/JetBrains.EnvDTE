namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsPublishableProjectCfg
    {
        int AdvisePublishStatusCallback(
            IVsPublishableProjectStatusCallback pIVsPublishStatusCallback,
            out uint pdwCookie);

        int UnadvisePublishStatusCallback(uint dwCookie);

        int StartPublish(object pIVsOutputWindowPane, uint dwOptions);

        int QueryStatusPublish(out int pfPublishDone);

        int StopPublish(int fSync);

        int ShowPublishPrompt(out int pfContinue);

        int QueryStartPublish(uint dwOptions, int[] pfSupported, int[] pfReady);

        int GetPublishProperty(uint propid, out object pvar);
    }
}
