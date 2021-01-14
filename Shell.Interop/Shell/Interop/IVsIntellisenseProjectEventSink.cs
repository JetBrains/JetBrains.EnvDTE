namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsIntellisenseProjectEventSink
    {
        int OnStatusChange(uint dwStatus);

        int OnReferenceChange(uint dwChangeType, string pszAssemblyPath);

        int OnConfigChange();

        int OnCodeFileChange(string pszOldCodeFile, string pszNewCodeFile);
    }
}
