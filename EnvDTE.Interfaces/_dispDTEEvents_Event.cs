namespace EnvDTE
{
	public interface _dispDTEEvents_Event
	{
		event _dispDTEEvents_OnStartupCompleteEventHandler OnStartupComplete;
		event _dispDTEEvents_OnBeginShutdownEventHandler OnBeginShutdown;
		event _dispDTEEvents_ModeChangedEventHandler ModeChanged;
		event _dispDTEEvents_OnMacrosRuntimeResetEventHandler OnMacrosRuntimeReset;
	}
}
