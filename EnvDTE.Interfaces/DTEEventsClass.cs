namespace EnvDTE
{
    public class DTEEventsClass : _DTEEvents, DTEEvents, _dispDTEEvents_Event
    {
        public  DTEEventsClass(){ }
        public virtual event _dispDTEEvents_OnStartupCompleteEventHandler OnStartupComplete;
        public virtual event _dispDTEEvents_OnBeginShutdownEventHandler OnBeginShutdown;
        public virtual event _dispDTEEvents_ModeChangedEventHandler ModeChanged;
        public virtual event _dispDTEEvents_OnMacrosRuntimeResetEventHandler OnMacrosRuntimeReset;
    }
}
