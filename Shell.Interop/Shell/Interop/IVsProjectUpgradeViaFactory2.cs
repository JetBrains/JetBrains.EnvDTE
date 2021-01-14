namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProjectUpgradeViaFactory2
    {
        int OnUpgradeProjectCancelled( string bstrFileName);
    }
}
