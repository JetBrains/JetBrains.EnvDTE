namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsWebServiceProvider
    {
        int WebServices(out IEnumWebServices ppIEnumWebServices);


        int GetWebService(string pszUrl, out IVsWebService ppIVsWebService);


        int StartServer();


        int AdviseWebServiceProviderEvents(IVsWebServiceProviderEvents pEvents, out uint pdwCookie);


        int UnadviseWebServiceProviderEvents(uint dwCookie);


        int EnsureServerRunning(out string pbstrUrl);


        int ApplicationUrl(out string pbstrUrl);
    }
}
