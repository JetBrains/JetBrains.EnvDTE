namespace EnvDTE80
{
	public interface _dispDebuggerProcessEvents_Event
	{
		event _dispDebuggerProcessEvents_OnProcessStateChangedEventHandler OnProcessStateChanged;

		void add_OnProcessStateChanged(
			_dispDebuggerProcessEvents_OnProcessStateChangedEventHandler A_1);

		void remove_OnProcessStateChanged(
			_dispDebuggerProcessEvents_OnProcessStateChangedEventHandler A_1);
	}
}
