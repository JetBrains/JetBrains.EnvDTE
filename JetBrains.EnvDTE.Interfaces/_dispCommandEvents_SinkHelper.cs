using System;

namespace EnvDTE
{
	public sealed class _dispCommandEvents_SinkHelper : _dispCommandEvents
	{
		public _dispCommandEvents_AfterExecuteEventHandler m_AfterExecuteDelegate;
		public _dispCommandEvents_BeforeExecuteEventHandler m_BeforeExecuteDelegate;
		public int m_dwCookie;

		internal _dispCommandEvents_SinkHelper()
		{
		}

		public void BeforeExecute(string A_1, int A_2, object A_3, object A_4, ref bool A_5)
		{
			throw new NotImplementedException();
		}

		public void AfterExecute(string A_1, int A_2, object A_3, object A_4)
		{
			throw new NotImplementedException();
		}
	}
}
