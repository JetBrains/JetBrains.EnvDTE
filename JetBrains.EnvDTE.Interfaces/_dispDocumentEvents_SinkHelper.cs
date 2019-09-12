using System;

namespace EnvDTE
{
	public sealed class _dispDocumentEvents_SinkHelper : _dispDocumentEvents
	{
		public _dispDocumentEvents_DocumentClosingEventHandler m_DocumentClosingDelegate;
		public _dispDocumentEvents_DocumentOpenedEventHandler m_DocumentOpenedDelegate;
		public _dispDocumentEvents_DocumentOpeningEventHandler m_DocumentOpeningDelegate;
		public _dispDocumentEvents_DocumentSavedEventHandler m_DocumentSavedDelegate;
		public int m_dwCookie;

		internal _dispDocumentEvents_SinkHelper()
		{
		}

		public void DocumentSaved(Document A_1)
		{
			throw new NotImplementedException();
		}

		public void DocumentClosing(Document A_1)
		{
			throw new NotImplementedException();
		}

		public void DocumentOpening(string A_1, bool A_2)
		{
			throw new NotImplementedException();
		}

		public void DocumentOpened(Document A_1)
		{
			throw new NotImplementedException();
		}
	}
}
