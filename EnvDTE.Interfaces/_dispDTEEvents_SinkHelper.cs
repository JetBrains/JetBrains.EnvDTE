using System;

namespace EnvDTE
{
	public sealed class _dispDTEEvents_SinkHelper : _dispDTEEvents
	{
		public int m_dwCookie;
		public _dispDTEEvents_ModeChangedEventHandler m_ModeChangedDelegate;
		public _dispDTEEvents_OnBeginShutdownEventHandler m_OnBeginShutdownDelegate;
		public _dispDTEEvents_OnMacrosRuntimeResetEventHandler m_OnMacrosRuntimeResetDelegate;
		public _dispDTEEvents_OnStartupCompleteEventHandler m_OnStartupCompleteDelegate;

		internal _dispDTEEvents_SinkHelper()
		{
		}

		public void OnStartupComplete()
		{
			throw new NotImplementedException();
		}

		public void OnBeginShutdown()
		{
			throw new NotImplementedException();
		}

		public void ModeChanged(vsIDEMode A_1)
		{
			throw new NotImplementedException();
		}

		public void OnMacrosRuntimeReset()
		{
			throw new NotImplementedException();
		}
	}
}
