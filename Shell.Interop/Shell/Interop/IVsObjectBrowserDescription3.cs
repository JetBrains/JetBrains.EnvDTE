namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsObjectBrowserDescription3
    {
        int AddDescriptionText3(string pText, object obdSect, IVsNavInfo pHyperJump);

        int ClearDescriptionText();
    }
}
