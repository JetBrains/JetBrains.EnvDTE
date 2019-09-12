using System;

namespace EnvDTE
{
	public sealed class _dispFindEvents_SinkHelper : _dispFindEvents
	{
		public int m_dwCookie;
		public _dispFindEvents_FindDoneEventHandler m_FindDoneDelegate;

		internal _dispFindEvents_SinkHelper()
		{
		}

		public void FindDone(vsFindResult A_1, bool A_2)
		{
			throw new NotImplementedException();
		}
	}
}
