namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsWindowFrame2
    {

        int Advise( object pNotify,  out uint pdwCookie);


        int Unadvise( uint dwCookie);

        int ActivateOwnerDockedWindow();
    }
}
