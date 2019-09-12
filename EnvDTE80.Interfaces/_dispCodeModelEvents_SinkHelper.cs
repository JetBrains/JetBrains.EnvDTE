
using EnvDTE;


namespace EnvDTE80
{
	public sealed class _dispCodeModelEvents_SinkHelper : _dispCodeModelEvents
	{
		public int m_dwCookie;
		public _dispCodeModelEvents_ElementAddedEventHandler m_ElementAddedDelegate;
		public _dispCodeModelEvents_ElementChangedEventHandler m_ElementChangedDelegate;
		public _dispCodeModelEvents_ElementDeletedEventHandler m_ElementDeletedDelegate;

		internal _dispCodeModelEvents_SinkHelper()
		{
			m_dwCookie = 0;
			m_ElementAddedDelegate = null;
			m_ElementChangedDelegate = null;
			m_ElementDeletedDelegate = null;
		}

		public void ElementAdded(CodeElement A_1)
		{
			if (m_ElementAddedDelegate == null)
				return;
			m_ElementAddedDelegate(A_1);
		}

		public void ElementChanged(CodeElement A_1, vsCMChangeKind A_2)
		{
			if (m_ElementChangedDelegate == null)
				return;
			m_ElementChangedDelegate(A_1, A_2);
		}

		public void ElementDeleted(object A_1, CodeElement A_2)
		{
			if (m_ElementDeletedDelegate == null)
				return;
			m_ElementDeletedDelegate(A_1, A_2);
		}
	}
}
