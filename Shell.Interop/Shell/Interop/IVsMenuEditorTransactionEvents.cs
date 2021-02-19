namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsMenuEditorTransactionEvents
    {
        int BeginTransaction(uint trans);

        int EndTransaction(uint trans);
    }
}
