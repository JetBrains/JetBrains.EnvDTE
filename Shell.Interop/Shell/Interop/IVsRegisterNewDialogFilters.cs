namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsRegisterNewDialogFilters
    {
        int RegisterNewProjectDialogFilter(object pFilter, out uint pdwFilterCookie);

        int UnregisterNewProjectDialogFilter(uint dwFilterCookie);

        int RegisterAddNewItemDialogFilter(object pFilter, out uint pdwFilterCookie);

        int UnregisterAddNewItemDialogFilter(uint dwFilterCookie);
    }
}
