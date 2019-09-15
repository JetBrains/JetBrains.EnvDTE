namespace EnvDTE
{
    public class DebuggerEventsClass : _DebuggerEvents, DebuggerEvents, _dispDebuggerEvents_Event
    {
        public extern DebuggerEventsClass();
        public virtual extern event _dispDebuggerEvents_OnEnterRunModeEventHandler OnEnterRunMode;
        public virtual extern event _dispDebuggerEvents_OnEnterDesignModeEventHandler OnEnterDesignMode;
        public virtual extern event _dispDebuggerEvents_OnEnterBreakModeEventHandler OnEnterBreakMode;
        public virtual extern event _dispDebuggerEvents_OnExceptionThrownEventHandler OnExceptionThrown;
        public virtual extern event _dispDebuggerEvents_OnExceptionNotHandledEventHandler OnExceptionNotHandled;
        public virtual extern event _dispDebuggerEvents_OnContextChangedEventHandler OnContextChanged;
    }
}
