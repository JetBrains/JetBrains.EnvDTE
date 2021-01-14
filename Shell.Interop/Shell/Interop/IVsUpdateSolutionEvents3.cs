namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsUpdateSolutionEvents3
    {

        int OnBeforeActiveSolutionCfgChange( object pOldActiveSlnCfg,  object pNewActiveSlnCfg);


        int OnAfterActiveSolutionCfgChange( object pOldActiveSlnCfg,  object pNewActiveSlnCfg);
    }
}
