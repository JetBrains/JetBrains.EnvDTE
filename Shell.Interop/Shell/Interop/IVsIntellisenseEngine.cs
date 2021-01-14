namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsIntellisenseEngine
    {
        int Load();

        int Unload();

        int SupportsLoad();
    }
}
