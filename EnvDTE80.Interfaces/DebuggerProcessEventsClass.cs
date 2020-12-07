namespace EnvDTE80
{
    public class DebuggerProcessEventsClass : _DebuggerProcessEvents, DebuggerProcessEvents,
        _dispDebuggerProcessEvents_Event
    {
        public DebuggerProcessEventsClass(){ }
        public virtual event _dispDebuggerProcessEvents_OnProcessStateChangedEventHandler OnProcessStateChanged;
    }
}
