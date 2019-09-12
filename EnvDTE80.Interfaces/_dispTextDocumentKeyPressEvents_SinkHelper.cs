
using EnvDTE;


namespace EnvDTE80
{
	public sealed class _dispTextDocumentKeyPressEvents_SinkHelper : _dispTextDocumentKeyPressEvents
	{
		public _dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler m_AfterKeyPressDelegate;
		public _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler m_BeforeKeyPressDelegate;
		public int m_dwCookie;

		internal _dispTextDocumentKeyPressEvents_SinkHelper()
		{
			m_dwCookie = 0;
			m_BeforeKeyPressDelegate = null;
			m_AfterKeyPressDelegate = null;
		}

		public void BeforeKeyPress(string A_1, TextSelection A_2, bool A_3, ref bool A_4)
		{
			if (m_BeforeKeyPressDelegate == null)
				return;
			m_BeforeKeyPressDelegate(A_1, A_2, A_3, ref A_4);
		}

		public void AfterKeyPress(string A_1, TextSelection A_2, bool A_3)
		{
			if (m_AfterKeyPressDelegate == null)
				return;
			m_AfterKeyPressDelegate(A_1, A_2, A_3);
		}
	}
}
