namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsTypeLibraryWrapperBatchSupport
    {
        int StartBatch();


        int StopBatch();
    }
}
