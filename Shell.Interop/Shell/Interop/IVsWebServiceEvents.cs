namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsWebServiceEvents
    {
        int OnRemoved(string pszOldURL);


        int OnRenamed(string pszOldURL, string pszNewURL);


        int OnChanged(IVsWebService pIVsWebReference);
    }
}
