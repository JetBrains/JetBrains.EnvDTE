using System;

namespace EnvDTE
{
    internal sealed class _dispProjectsEvents_EventProvider : _dispProjectsEvents_Event, IDisposable
    {
        public _dispProjectsEvents_EventProvider(object A_1)
        {
        }

        public event _dispProjectsEvents_ItemAddedEventHandler ItemAdded;
        public event _dispProjectsEvents_ItemRemovedEventHandler ItemRemoved;
        public event _dispProjectsEvents_ItemRenamedEventHandler ItemRenamed;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
