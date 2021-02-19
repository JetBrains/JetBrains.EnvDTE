namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsIntellisenseProject
    {
        int Init(IVsIntellisenseProjectHost pHost);

        int Close();

        int AddFile(string bstrAbsPath, uint itemid);

        int RemoveFile(string bstrAbsPath, uint itemid);

        int RenameFile(string bstrAbsPath, string bstrNewAbsPath, uint itemid);

        int IsCompilableFile(string bstrFileName);

        int GetContainedLanguageFactory(out object ppContainedLanguageFactory);

        int GetCompilerReference(out object ppCompilerReference);

        int GetFileCodeModel(object pProj, object pProjectItem, out object ppCodeModel);

        int GetProjectCodeModel(object pProj, out object ppCodeModel);

        int RefreshCompilerOptions();

        int GetCodeDomProviderName(out string pbstrProvider);

        int IsWebFileRequiredByProject(out int pbReq);

        int AddAssemblyReference(string bstrAbsPath);

        int RemoveAssemblyReference(string bstrAbsPath);

        int AddP2PReference(object pUnk);

        int RemoveP2PReference(object pUnk);

        int StopIntellisenseEngine();

        int StartIntellisenseEngine();

        int IsSupportedP2PReference(object pUnk);

        int WaitForIntellisenseReady();

        int GetExternalErrorReporter(out object ppErrorReporter);

        int SuspendPostedNotifications();

        int ResumePostedNotifications();
    }
}
