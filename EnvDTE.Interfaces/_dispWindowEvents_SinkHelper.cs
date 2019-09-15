using System;

namespace EnvDTE
{
    public sealed class _dispWindowEvents_SinkHelper : _dispWindowEvents
    {
        public int m_dwCookie;
        public _dispWindowEvents_WindowActivatedEventHandler m_WindowActivatedDelegate;
        public _dispWindowEvents_WindowClosingEventHandler m_WindowClosingDelegate;
        public _dispWindowEvents_WindowCreatedEventHandler m_WindowCreatedDelegate;
        public _dispWindowEvents_WindowMovedEventHandler m_WindowMovedDelegate;

        internal _dispWindowEvents_SinkHelper()
        {
        }

        public void WindowClosing(Window A_1)
        {
            throw new NotImplementedException();
        }

        public void WindowMoved(Window A_1, int A_2, int A_3, int A_4, int A_5)
        {
            throw new NotImplementedException();
        }

        public void WindowActivated(Window A_1, Window A_2)
        {
            throw new NotImplementedException();
        }

        public void WindowCreated(Window A_1)
        {
            throw new NotImplementedException();
        }
    }
}
