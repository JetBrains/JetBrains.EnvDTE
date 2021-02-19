namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsRegisterProjectDebugTargetProvider
    {
        int AddDebugTargetProvider(
            IVsProjectDebugTargetProvider pNewDbgTrgtProvider,
            out IVsProjectDebugTargetProvider ppNextDbgTrgtProvider);

        int RemoveDebugTargetProvider(IVsProjectDebugTargetProvider pDbgTrgtProvider);
    }
}
