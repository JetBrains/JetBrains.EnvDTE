namespace EnvDTE
{
	public class DocumentEventsClass : _DocumentEvents, DocumentEvents, _dispDocumentEvents_Event
	{
		public extern DocumentEventsClass();
		public virtual extern event _dispDocumentEvents_DocumentSavedEventHandler DocumentSaved;
		public virtual extern event _dispDocumentEvents_DocumentClosingEventHandler DocumentClosing;
		public virtual extern event _dispDocumentEvents_DocumentOpeningEventHandler DocumentOpening;
		public virtual extern event _dispDocumentEvents_DocumentOpenedEventHandler DocumentOpened;
	}
}
