using System;

namespace EnvDTE
{
    public sealed class _dispProjectsEvents_SinkHelper : _dispProjectsEvents
    {
        public int m_dwCookie;
        public _dispProjectsEvents_ItemAddedEventHandler m_ItemAddedDelegate;
        public _dispProjectsEvents_ItemRemovedEventHandler m_ItemRemovedDelegate;
        public _dispProjectsEvents_ItemRenamedEventHandler m_ItemRenamedDelegate;

        internal _dispProjectsEvents_SinkHelper()
        {
        }

        public void ItemAdded(Project A_1)
        {
            throw new NotImplementedException();
        }

        public void ItemRemoved(Project A_1)
        {
            throw new NotImplementedException();
        }

        public void ItemRenamed(Project A_1, string A_2)
        {
            throw new NotImplementedException();
        }
    }
}
