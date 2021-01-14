namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsToolboxActiveUserHook
    {
        int InterceptDataObject(object pIn, out object ppOut);

        int ToolboxSelectionChanged(object pSelected);
    }
}
