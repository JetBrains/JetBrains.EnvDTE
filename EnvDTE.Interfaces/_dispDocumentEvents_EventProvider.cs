using System;

namespace EnvDTE
{
    internal sealed class _dispDocumentEvents_EventProvider : _dispDocumentEvents_Event, IDisposable
    {
        public _dispDocumentEvents_EventProvider(object A_1)
        {
        }

        public event _dispDocumentEvents_DocumentSavedEventHandler DocumentSaved;
        public event _dispDocumentEvents_DocumentClosingEventHandler DocumentClosing;
        public event _dispDocumentEvents_DocumentOpeningEventHandler DocumentOpening;
        public event _dispDocumentEvents_DocumentOpenedEventHandler DocumentOpened;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
