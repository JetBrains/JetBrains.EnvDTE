using System;

namespace EnvDTE80
{
    internal sealed class _dispTextDocumentKeyPressEvents_EventProvider : _dispTextDocumentKeyPressEvents_Event,
        IDisposable
    {
        public _dispTextDocumentKeyPressEvents_EventProvider(object A_1)
        {
        }

        public event _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler BeforeKeyPress;
        public event _dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler AfterKeyPress;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
