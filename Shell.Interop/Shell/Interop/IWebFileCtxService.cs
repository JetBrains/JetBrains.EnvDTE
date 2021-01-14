namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IWebFileCtxService
    {
        int AddFileToIntellisense(string pszFilePath, out uint pItemid);

        int EnsureFileOpened(uint itemid, out object ppFrame);


        int RemoveFileFromIntellisense(string pszFilePath);


        int GetWebRootPath(out string pbstrWebRootPath);


        int GetIntellisenseProjectName(out string pbstrProjectName);


        int AddDependentAssemblyFile(string pszFilePath);


        int RemoveDependentAssemblyFile(string pszFilePath);


        int ConvertToAppRelPath(string pszFilePath, out string pbstrAppRelPath);


        int CBMCallbackActive();


        int WaitForIntellisenseReady();


        int IsDocumentInProject(string pszFilePath, out uint pItemid);
    }
}
