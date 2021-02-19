namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsWebService
    {
        int Url(out string bstrUrl);


        int AppRelativeUrl(out string bstrAppUrl);


        int GetProvider(out IVsWebServiceProvider ppIVsWebServiceProvider);


        int AdviseWebServiceEvents(IVsWebServiceEvents pEvents, out uint pdwCookie);


        int UnadviseWebServiceEvents(uint dwCookie);
    }
}
