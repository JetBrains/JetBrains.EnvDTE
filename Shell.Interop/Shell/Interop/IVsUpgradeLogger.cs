namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsUpgradeLogger
    {
        int LogMessage(uint ErrorLevel, string bstrProject, string bstrSource, string bstrDescription);

        int Flush();
    }
}
