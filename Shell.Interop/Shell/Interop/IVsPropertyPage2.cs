namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsPropertyPage2
    {
        int GetProperty(uint propid, out object pvar);

        int SetProperty(uint propid, object var);
    }
}
