namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsQueryDebuggableProjectCfg
    {
        int QueryDebugTargets(
            uint grfLaunch,
            uint cTargets,
            object[] rgDebugTargetInfo,
            uint[] pcActual);
    }
}
