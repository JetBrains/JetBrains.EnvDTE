namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsUIShellOpenDocument2
    {

        int GetDefaultPreviewers(
             uint celt,
             VSDEFAULTPREVIEWER[] rgDefaultPreviewers,
             out uint pcActual);
    }
}
