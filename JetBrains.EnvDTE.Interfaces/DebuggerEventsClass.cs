namespace EnvDTE
{
	public class DebuggerEventsClass : _DebuggerEvents, DebuggerEvents, _dispDebuggerEvents_Event
	{
		public extern DebuggerEventsClass();
		public virtual extern event _dispDebuggerEvents_OnEnterRunModeEventHandler OnEnterRunMode;
		public virtual extern void add_OnEnterRunMode(_dispDebuggerEvents_OnEnterRunModeEventHandler A_1);

		public virtual extern void remove_OnEnterRunMode(
			_dispDebuggerEvents_OnEnterRunModeEventHandler A_1);

		public virtual extern void add_OnEnterDesignMode(
			_dispDebuggerEvents_OnEnterDesignModeEventHandler A_1);

		public virtual extern event _dispDebuggerEvents_OnEnterDesignModeEventHandler OnEnterDesignMode;

		public virtual extern void remove_OnEnterDesignMode(
			_dispDebuggerEvents_OnEnterDesignModeEventHandler A_1);

		public virtual extern event _dispDebuggerEvents_OnEnterBreakModeEventHandler OnEnterBreakMode;

		public virtual extern void add_OnEnterBreakMode(
			_dispDebuggerEvents_OnEnterBreakModeEventHandler A_1);

		public virtual extern void remove_OnEnterBreakMode(
			_dispDebuggerEvents_OnEnterBreakModeEventHandler A_1);

		public virtual extern event _dispDebuggerEvents_OnExceptionThrownEventHandler OnExceptionThrown;

		public virtual extern void add_OnExceptionThrown(
			_dispDebuggerEvents_OnExceptionThrownEventHandler A_1);

		public virtual extern void remove_OnExceptionThrown(
			_dispDebuggerEvents_OnExceptionThrownEventHandler A_1);

		public virtual extern void add_OnExceptionNotHandled(
			_dispDebuggerEvents_OnExceptionNotHandledEventHandler A_1);

		public virtual extern event _dispDebuggerEvents_OnExceptionNotHandledEventHandler OnExceptionNotHandled;

		public virtual extern void remove_OnExceptionNotHandled(
			_dispDebuggerEvents_OnExceptionNotHandledEventHandler A_1);

		public virtual extern event _dispDebuggerEvents_OnContextChangedEventHandler OnContextChanged;

		public virtual extern void add_OnContextChanged(
			_dispDebuggerEvents_OnContextChangedEventHandler A_1);

		public virtual extern void remove_OnContextChanged(
			_dispDebuggerEvents_OnContextChangedEventHandler A_1);
	}
}
