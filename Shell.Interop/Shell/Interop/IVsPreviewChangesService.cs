namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsPreviewChangesService
    {
        int PreviewChanges(IVsPreviewChangesEngine pIVsPreviewChangesEngine);
    }
}
