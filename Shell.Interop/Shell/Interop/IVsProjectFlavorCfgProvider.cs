namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProjectFlavorCfgProvider
    {
        int CreateProjectFlavorCfg(object pBaseProjectCfg, out IVsProjectFlavorCfg ppFlavorCfg);
    }
}
