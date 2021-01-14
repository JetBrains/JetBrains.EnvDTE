namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProjectDebugTargetProvider
    {
        int SupplyDebugTarget(out string pbstrTarget, out string pbstrCommandLine);
    }
}
