namespace EnvDTE80
{
	public sealed class _dispPublishEvents_SinkHelper : _dispPublishEvents
	{
		public int m_dwCookie;
		public _dispPublishEvents_OnPublishBeginEventHandler m_OnPublishBeginDelegate;
		public _dispPublishEvents_OnPublishDoneEventHandler m_OnPublishDoneDelegate;

		internal _dispPublishEvents_SinkHelper()
		{
			m_dwCookie = 0;
			m_OnPublishBeginDelegate = null;
			m_OnPublishDoneDelegate = null;
		}

		public void OnPublishBegin(ref bool A_1)
		{
			if (m_OnPublishBeginDelegate == null)
				return;
			m_OnPublishBeginDelegate(ref A_1);
		}

		public void OnPublishDone(bool A_1)
		{
			if (m_OnPublishDoneDelegate == null)
				return;
			m_OnPublishDoneDelegate(A_1);
		}
	}
}
