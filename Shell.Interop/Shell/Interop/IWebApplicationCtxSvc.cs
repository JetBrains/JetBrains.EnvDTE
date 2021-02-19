namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IWebApplicationCtxSvc
    {

        int GetItemContext( object pHier,  uint itemid,  out object ppServiceProvider);
    }
}
