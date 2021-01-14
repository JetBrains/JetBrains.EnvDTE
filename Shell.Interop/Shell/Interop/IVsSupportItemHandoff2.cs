namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSupportItemHandoff2
    {
        int OnBeforeHandoffItem(uint itemid, object pProjDest);
    }
}
