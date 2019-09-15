using System;

namespace EnvDTE
{
    public sealed class _dispSelectionEvents_SinkHelper : _dispSelectionEvents
    {
        public int m_dwCookie;
        public _dispSelectionEvents_OnChangeEventHandler m_OnChangeDelegate;

        internal _dispSelectionEvents_SinkHelper()
        {
        }

        public void OnChange()
        {
            throw new NotImplementedException();
        }
    }
}
