namespace EnvDTE
{
	public class DTEEventsClass : _DTEEvents, DTEEvents, _dispDTEEvents_Event
	{
		public extern DTEEventsClass();
		public virtual extern event _dispDTEEvents_OnStartupCompleteEventHandler OnStartupComplete;
		public virtual extern event _dispDTEEvents_OnBeginShutdownEventHandler OnBeginShutdown;
		public virtual extern event _dispDTEEvents_ModeChangedEventHandler ModeChanged;
		public virtual extern event _dispDTEEvents_OnMacrosRuntimeResetEventHandler OnMacrosRuntimeReset;
	}
}
