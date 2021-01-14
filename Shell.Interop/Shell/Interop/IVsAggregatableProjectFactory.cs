namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsAggregatableProjectFactory
    {
        int GetAggregateProjectType(string pszFilename,  out string pbstrProjTypeGuid);

        int PreCreateForOuter( object punkOuter,  out object ppunkProject);
    }
}
