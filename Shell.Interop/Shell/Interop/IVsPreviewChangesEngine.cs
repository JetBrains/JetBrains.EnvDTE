namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsPreviewChangesEngine
    {
        int GetTitle(out string pbstrTitle);

        int GetDescription(out string pbstrDescription);

        int GetTextViewDescription(out string pbstrTextViewDescription);

        int GetWarning(out string pbstrWarning, out int ppcwlWarningLevel);

        int GetHelpContext(out string pbstrHelpContext);

        int GetConfirmation(out string pbstrConfirmation);

        int GetRootChangesList(out object ppIUnknownPreviewChangesList);

        int ApplyChanges();
    }
}
