namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsNavInfoNode
    {
        int get_Type(out uint pllt);

        int get_Name(out string pbstrName);
    }
}
