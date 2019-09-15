using System;

namespace EnvDTE
{
    internal sealed class _dispOutputWindowEvents_EventProvider : _dispOutputWindowEvents_Event, IDisposable
    {
        public _dispOutputWindowEvents_EventProvider(object A_1)
        {
        }

        public event _dispOutputWindowEvents_PaneAddedEventHandler PaneAdded;
        public event _dispOutputWindowEvents_PaneUpdatedEventHandler PaneUpdated;
        public event _dispOutputWindowEvents_PaneClearingEventHandler PaneClearing;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
