namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccToolsOptions
    {
        int SetSccToolsOption(object sctoOptionToBeSet, object varValueToBeSet);

        int GetSccToolsOption(object sctoOptionToBeSet, out object pvarValueToGet);
    }
}
