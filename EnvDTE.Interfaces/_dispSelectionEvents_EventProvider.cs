
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;


namespace EnvDTE
{
	internal sealed class _dispSelectionEvents_EventProvider : _dispSelectionEvents_Event, IDisposable
	{
		public _dispSelectionEvents_EventProvider(object A_1)
		{
		}

		public event _dispSelectionEvents_OnChangeEventHandler OnChange;

		public void Dispose()
		{
		}

		public void Finalize()
		{
		}
	}
}
