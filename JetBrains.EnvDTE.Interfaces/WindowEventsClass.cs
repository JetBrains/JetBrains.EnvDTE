namespace EnvDTE
{
	public class WindowEventsClass : _WindowEvents, WindowEvents, _dispWindowEvents_Event
	{
		public extern WindowEventsClass();
		public virtual extern event _dispWindowEvents_WindowClosingEventHandler WindowClosing;
		public virtual extern void add_WindowClosing(_dispWindowEvents_WindowClosingEventHandler A_1);
		public virtual extern void remove_WindowClosing(_dispWindowEvents_WindowClosingEventHandler A_1);
		public virtual extern event _dispWindowEvents_WindowMovedEventHandler WindowMoved;
		public virtual extern void add_WindowMoved(_dispWindowEvents_WindowMovedEventHandler A_1);
		public virtual extern void remove_WindowMoved(_dispWindowEvents_WindowMovedEventHandler A_1);
		public virtual extern event _dispWindowEvents_WindowActivatedEventHandler WindowActivated;
		public virtual extern void add_WindowActivated(_dispWindowEvents_WindowActivatedEventHandler A_1);

		public virtual extern void remove_WindowActivated(
			_dispWindowEvents_WindowActivatedEventHandler A_1);

		public virtual extern event _dispWindowEvents_WindowCreatedEventHandler WindowCreated;
		public virtual extern void add_WindowCreated(_dispWindowEvents_WindowCreatedEventHandler A_1);
		public virtual extern void remove_WindowCreated(_dispWindowEvents_WindowCreatedEventHandler A_1);
	}
}
