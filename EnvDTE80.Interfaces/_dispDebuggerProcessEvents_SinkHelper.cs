using EnvDTE;

namespace EnvDTE80
{
    public sealed class _dispDebuggerProcessEvents_SinkHelper : _dispDebuggerProcessEvents
    {
        public int m_dwCookie;
        public _dispDebuggerProcessEvents_OnProcessStateChangedEventHandler m_OnProcessStateChangedDelegate;

        internal _dispDebuggerProcessEvents_SinkHelper()
        {
            m_dwCookie = 0;
            m_OnProcessStateChangedDelegate = null;
        }

        public void OnProcessStateChanged(Process A_1, dbgProcessState A_2)
        {
            if (m_OnProcessStateChangedDelegate == null)
                return;
            m_OnProcessStateChangedDelegate(A_1, A_2);
        }
    }
}
