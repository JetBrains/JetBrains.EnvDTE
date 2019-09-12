namespace EnvDTE80
{
	public class DebuggerProcessEventsClass : _DebuggerProcessEvents, DebuggerProcessEvents,
		_dispDebuggerProcessEvents_Event
	{
		public extern DebuggerProcessEventsClass();
		public virtual extern event _dispDebuggerProcessEvents_OnProcessStateChangedEventHandler OnProcessStateChanged;

		public virtual extern void add_OnProcessStateChanged(
			_dispDebuggerProcessEvents_OnProcessStateChangedEventHandler A_1);

		public virtual extern void remove_OnProcessStateChanged(
			_dispDebuggerProcessEvents_OnProcessStateChangedEventHandler A_1);
	}
}
