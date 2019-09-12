namespace EnvDTE
{
	public class DocumentEventsClass : _DocumentEvents, DocumentEvents, _dispDocumentEvents_Event
	{
		public extern DocumentEventsClass();
		public virtual extern event _dispDocumentEvents_DocumentSavedEventHandler DocumentSaved;
		public virtual extern void add_DocumentSaved(_dispDocumentEvents_DocumentSavedEventHandler A_1);

		public virtual extern void remove_DocumentSaved(
			_dispDocumentEvents_DocumentSavedEventHandler A_1);

		public virtual extern event _dispDocumentEvents_DocumentClosingEventHandler DocumentClosing;

		public virtual extern void add_DocumentClosing(
			_dispDocumentEvents_DocumentClosingEventHandler A_1);

		public virtual extern void remove_DocumentClosing(
			_dispDocumentEvents_DocumentClosingEventHandler A_1);

		public virtual extern event _dispDocumentEvents_DocumentOpeningEventHandler DocumentOpening;

		public virtual extern void add_DocumentOpening(
			_dispDocumentEvents_DocumentOpeningEventHandler A_1);

		public virtual extern void remove_DocumentOpening(
			_dispDocumentEvents_DocumentOpeningEventHandler A_1);

		public virtual extern event _dispDocumentEvents_DocumentOpenedEventHandler DocumentOpened;
		public virtual extern void add_DocumentOpened(_dispDocumentEvents_DocumentOpenedEventHandler A_1);

		public virtual extern void remove_DocumentOpened(
			_dispDocumentEvents_DocumentOpenedEventHandler A_1);
	}
}
