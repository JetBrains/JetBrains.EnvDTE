namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IWebClassLibProjectEvents
    {
        int OnReferenceAdded(string pszReferencePath);

        int OnFileAdded(string pszFilePath, bool foldersMustBeInProject);

        int StartWebAdminTool();
    }
}
