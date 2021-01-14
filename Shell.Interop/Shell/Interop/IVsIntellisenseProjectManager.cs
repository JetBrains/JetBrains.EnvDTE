namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsIntellisenseProjectManager
    {
        int AdviseIntellisenseProjectEvents(IVsIntellisenseProjectEventSink pSink, out uint pdwCookie);

        int UnadviseIntellisenseProjectEvents(uint dwCookie);

        int GetContainedLanguageFactory(
            string bstrLanguage,
            out object ppContainedLanguageFactory);

        int CloseIntellisenseProject();

        int OnEditorReady();

        int CompleteIntellisenseProjectLoad();
    }
}
