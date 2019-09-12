namespace EnvDTE
{
	public interface _dispDocumentEvents_Event
	{
		event _dispDocumentEvents_DocumentSavedEventHandler DocumentSaved;
		event _dispDocumentEvents_DocumentClosingEventHandler DocumentClosing;
		event _dispDocumentEvents_DocumentOpeningEventHandler DocumentOpening;
		event _dispDocumentEvents_DocumentOpenedEventHandler DocumentOpened;
	}
}
