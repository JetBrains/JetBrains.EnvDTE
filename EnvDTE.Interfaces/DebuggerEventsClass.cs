namespace EnvDTE
{
    public class DebuggerEventsClass : _DebuggerEvents, DebuggerEvents, _dispDebuggerEvents_Event
    {
        public DebuggerEventsClass(){ }
        public virtual event _dispDebuggerEvents_OnEnterRunModeEventHandler OnEnterRunMode;
        public virtual event _dispDebuggerEvents_OnEnterDesignModeEventHandler OnEnterDesignMode;
        public virtual event _dispDebuggerEvents_OnEnterBreakModeEventHandler OnEnterBreakMode;
        public virtual event _dispDebuggerEvents_OnExceptionThrownEventHandler OnExceptionThrown;
        public virtual event _dispDebuggerEvents_OnExceptionNotHandledEventHandler OnExceptionNotHandled;
        public virtual event _dispDebuggerEvents_OnContextChangedEventHandler OnContextChanged;
    }
}
