
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;


namespace EnvDTE
{
	internal sealed class _dispCommandEvents_EventProvider : _dispCommandEvents_Event, IDisposable
	{
		public _dispCommandEvents_EventProvider(object A_1)
		{
		}

		public event _dispCommandEvents_BeforeExecuteEventHandler BeforeExecute;
		public event _dispCommandEvents_AfterExecuteEventHandler AfterExecute;

		public void Dispose()
		{
		}

		public void Finalize()
		{
		}
	}
}
