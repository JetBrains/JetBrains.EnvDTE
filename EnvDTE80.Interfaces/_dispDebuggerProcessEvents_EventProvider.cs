using System;

namespace EnvDTE80
{
    internal sealed class _dispDebuggerProcessEvents_EventProvider : _dispDebuggerProcessEvents_Event, IDisposable
    {
        public _dispDebuggerProcessEvents_EventProvider(object A_1)
        {
        }

        public event _dispDebuggerProcessEvents_OnProcessStateChangedEventHandler OnProcessStateChanged;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
