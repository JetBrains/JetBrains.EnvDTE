namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSQLCLRReferencesUpdateCallback
    {
        int UpdateResult(
            string szAssembly,
            uint dwPermisionLevel,
            int hrUpdateResult,
            IErrorInfo pErrorInfo,
            uint updateAction);
    }
}
