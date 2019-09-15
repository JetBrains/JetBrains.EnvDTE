using EnvDTE;

namespace EnvDTE80
{
    public sealed class _dispWindowVisibilityEvents_SinkHelper : _dispWindowVisibilityEvents
    {
        public int m_dwCookie;
        public _dispWindowVisibilityEvents_WindowHidingEventHandler m_WindowHidingDelegate;
        public _dispWindowVisibilityEvents_WindowShowingEventHandler m_WindowShowingDelegate;

        internal _dispWindowVisibilityEvents_SinkHelper()
        {
            m_dwCookie = 0;
            m_WindowHidingDelegate = null;
            m_WindowShowingDelegate = null;
        }

        public void WindowHiding(Window A_1)
        {
            if (m_WindowHidingDelegate == null)
                return;
            m_WindowHidingDelegate(A_1);
        }

        public void WindowShowing(Window A_1)
        {
            if (m_WindowShowingDelegate == null)
                return;
            m_WindowShowingDelegate(A_1);
        }
    }
}
