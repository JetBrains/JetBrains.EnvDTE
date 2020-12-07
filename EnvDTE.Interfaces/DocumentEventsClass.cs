namespace EnvDTE
{
    public class DocumentEventsClass : _DocumentEvents, DocumentEvents, _dispDocumentEvents_Event
    {
        public DocumentEventsClass(){ }
        public virtual event _dispDocumentEvents_DocumentSavedEventHandler DocumentSaved;
        public virtual event _dispDocumentEvents_DocumentClosingEventHandler DocumentClosing;
        public virtual event _dispDocumentEvents_DocumentOpeningEventHandler DocumentOpening;
        public virtual event _dispDocumentEvents_DocumentOpenedEventHandler DocumentOpened;
    }
}
