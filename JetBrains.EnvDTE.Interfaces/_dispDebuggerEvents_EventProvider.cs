using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;

namespace EnvDTE
{
	internal sealed class _dispDebuggerEvents_EventProvider : _dispDebuggerEvents_Event, IDisposable
	{
		public _dispDebuggerEvents_EventProvider(object A_1)
		{
		}

		public event _dispDebuggerEvents_OnEnterRunModeEventHandler OnEnterRunMode;
		public event _dispDebuggerEvents_OnEnterDesignModeEventHandler OnEnterDesignMode;
		public event _dispDebuggerEvents_OnEnterBreakModeEventHandler OnEnterBreakMode;
		public event _dispDebuggerEvents_OnExceptionThrownEventHandler OnExceptionThrown;
		public event _dispDebuggerEvents_OnExceptionNotHandledEventHandler OnExceptionNotHandled;
		public event _dispDebuggerEvents_OnContextChangedEventHandler OnContextChanged;

		public void Dispose()
		{
		}

		public void Finalize()
		{
		}
	}
}
