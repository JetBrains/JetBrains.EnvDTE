namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsLibrary2Ex
    {
        int ProfileSettingsChanged();

        int GetNavInfoContainerData(IVsNavInfo pNavInfo, object[] pcsdComponent);

        int DoIdle();

        int SetContainerAsUnchanging(object[] pcsdComponent, int fUnchanging);
    }
}
