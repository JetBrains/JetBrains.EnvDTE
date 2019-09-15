namespace EnvDTE
{
    public interface _dispDocumentEvents
    {
        void DocumentSaved(Document Document);
        void DocumentClosing(Document Document);
        void DocumentOpening(string DocumentPath, bool ReadOnly);
        void DocumentOpened(Document Document);
    }
}
