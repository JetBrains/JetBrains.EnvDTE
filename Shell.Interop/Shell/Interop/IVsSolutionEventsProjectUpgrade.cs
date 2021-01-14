namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSolutionEventsProjectUpgrade
    {
        int OnAfterUpgradeProject(
            object pHierarchy,
            uint fUpgradeFlag,
            string bstrCopyLocation,
            SYSTEMTIME stUpgradeTime,
            IVsUpgradeLogger pLogger);
    }
}
