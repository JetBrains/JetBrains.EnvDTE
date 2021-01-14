namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsXMLMemberDataRegisterCallBack
    {
        int RegisterCallBack(object pIVsXMLMemberDataCallBack);


        int UnregisterCallBack();
    }
}
