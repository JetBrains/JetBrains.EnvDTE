namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProjectFactory2
    {
        int GetAsynchOpenProjectType( out uint pType);
    }
}
