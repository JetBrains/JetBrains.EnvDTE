using System;

namespace EnvDTE
{
	public sealed class _dispDebuggerEvents_SinkHelper : _dispDebuggerEvents
	{
		public int m_dwCookie;
		public _dispDebuggerEvents_OnContextChangedEventHandler m_OnContextChangedDelegate;
		public _dispDebuggerEvents_OnEnterBreakModeEventHandler m_OnEnterBreakModeDelegate;
		public _dispDebuggerEvents_OnEnterDesignModeEventHandler m_OnEnterDesignModeDelegate;
		public _dispDebuggerEvents_OnEnterRunModeEventHandler m_OnEnterRunModeDelegate;
		public _dispDebuggerEvents_OnExceptionNotHandledEventHandler m_OnExceptionNotHandledDelegate;
		public _dispDebuggerEvents_OnExceptionThrownEventHandler m_OnExceptionThrownDelegate;

		internal _dispDebuggerEvents_SinkHelper()
		{
		}

		public void OnEnterRunMode(dbgEventReason A_1)
		{
			throw new NotImplementedException();
		}

		public void OnEnterDesignMode(dbgEventReason A_1)
		{
			throw new NotImplementedException();
		}

		public void OnEnterBreakMode(dbgEventReason A_1, ref dbgExecutionAction A_2)
		{
			throw new NotImplementedException();
		}

		public void OnExceptionThrown(
			string A_1,
			string A_2,
			int A_3,
			string A_4,
			ref dbgExceptionAction A_5)
		{
			throw new NotImplementedException();
		}

		public void OnExceptionNotHandled(
			string A_1,
			string A_2,
			int A_3,
			string A_4,
			ref dbgExceptionAction A_5)
		{
			throw new NotImplementedException();
		}

		public void OnContextChanged(Process A_1, Program A_2, Thread A_3, StackFrame A_4)
		{
			throw new NotImplementedException();
		}
	}
}
