using System;

namespace EnvDTE
{
    internal sealed class _dispProjectItemsEvents_EventProvider : _dispProjectItemsEvents_Event, IDisposable
    {
        public _dispProjectItemsEvents_EventProvider(object A_1)
        {
        }

        public event _dispProjectItemsEvents_ItemAddedEventHandler ItemAdded;
        public event _dispProjectItemsEvents_ItemRemovedEventHandler ItemRemoved;
        public event _dispProjectItemsEvents_ItemRenamedEventHandler ItemRenamed;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
