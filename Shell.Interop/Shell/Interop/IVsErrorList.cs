namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsErrorList
    {
        int BringToFront();

        int ForceShowErrors();
    }
}
