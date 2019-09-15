using System;

namespace EnvDTE
{
    internal sealed class _dispDTEEvents_EventProvider : _dispDTEEvents_Event, IDisposable
    {
        public _dispDTEEvents_EventProvider(object A_1)
        {
        }

        public event _dispDTEEvents_OnStartupCompleteEventHandler OnStartupComplete;
        public event _dispDTEEvents_OnBeginShutdownEventHandler OnBeginShutdown;
        public event _dispDTEEvents_ModeChangedEventHandler ModeChanged;
        public event _dispDTEEvents_OnMacrosRuntimeResetEventHandler OnMacrosRuntimeReset;

        public void Dispose()
        {
        }

        private void Init()
        {
        }

        public void Finalize()
        {
        }
    }
}
