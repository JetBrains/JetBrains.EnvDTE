using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;

namespace EnvDTE
{
	internal sealed class _dispFindEvents_EventProvider : _dispFindEvents_Event, IDisposable
	{
		public _dispFindEvents_EventProvider(object A_1)
		{
		}

		public event _dispFindEvents_FindDoneEventHandler FindDone;

		public void Dispose()
		{
		}

		private void Init()
		{
		}

		public void Finalize()
		{
		}
	}
}
