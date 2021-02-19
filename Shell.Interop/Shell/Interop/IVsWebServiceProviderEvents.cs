namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsWebServiceProviderEvents
    {
        int OnAdded(IVsWebService pIVsWebReference);


        int OnRemoved(string pszUrl);
    }
}
