namespace EnvDTE80
{
    public class DebuggerProcessEventsClass : _DebuggerProcessEvents, DebuggerProcessEvents,
        _dispDebuggerProcessEvents_Event
    {
        public extern DebuggerProcessEventsClass();
        public virtual extern event _dispDebuggerProcessEvents_OnProcessStateChangedEventHandler OnProcessStateChanged;
    }
}
