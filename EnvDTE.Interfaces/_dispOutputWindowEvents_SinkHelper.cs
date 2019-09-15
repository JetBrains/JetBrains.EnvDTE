using System;

namespace EnvDTE
{
    public sealed class _dispOutputWindowEvents_SinkHelper : _dispOutputWindowEvents
    {
        public int m_dwCookie;
        public _dispOutputWindowEvents_PaneAddedEventHandler m_PaneAddedDelegate;
        public _dispOutputWindowEvents_PaneClearingEventHandler m_PaneClearingDelegate;
        public _dispOutputWindowEvents_PaneUpdatedEventHandler m_PaneUpdatedDelegate;

        internal _dispOutputWindowEvents_SinkHelper()
        {
        }

        public void PaneAdded(OutputWindowPane A_1)
        {
            throw new NotImplementedException();
        }

        public void PaneUpdated(OutputWindowPane A_1)
        {
            throw new NotImplementedException();
        }

        public void PaneClearing(OutputWindowPane A_1)
        {
            throw new NotImplementedException();
        }
    }
}
