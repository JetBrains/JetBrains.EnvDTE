namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsPublishableProjectStatusCallback
    {
        int PublishBegin(ref int pfContinue);

        int PublishEnd(int fSuccess);

        int Tick(ref int pfContinue);
    }
}
