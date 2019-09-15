using System;

namespace EnvDTE
{
    internal sealed class _dispTextEditorEvents_EventProvider : _dispTextEditorEvents_Event, IDisposable
    {
        public _dispTextEditorEvents_EventProvider(object A_1)
        {
        }

        public event _dispTextEditorEvents_LineChangedEventHandler LineChanged;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
