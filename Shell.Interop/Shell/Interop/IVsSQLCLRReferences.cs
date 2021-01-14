namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSQLCLRReferences
    {
        int InvokeNewReferencesDlg(
            object pConnection,
            object pAssemblySupport,
            uint dwAddNewReferenceFlags,
            string szLocalCache,
            uint dwProjectPermisionLevel,
            object pComponentUserCallback);


        int UpdateReferences(
            object pConnection,
            object pAssemblySupport,
            uint dwReferenceUpdateFlags,
            uint cAssemblyCount,
            string[] rgszAssemblies,
            string szLocalCache,
            uint dwProjectPermisionLevel,
            IVsSQLCLRReferencesUpdateCallback pCallBack);
    }
}
