namespace EnvDTE
{
	public class WindowEventsClass : _WindowEvents, WindowEvents, _dispWindowEvents_Event
	{
		public extern WindowEventsClass();
		public virtual extern event _dispWindowEvents_WindowClosingEventHandler WindowClosing;
		public virtual extern event _dispWindowEvents_WindowMovedEventHandler WindowMoved;
		public virtual extern event _dispWindowEvents_WindowActivatedEventHandler WindowActivated;
		public virtual extern event _dispWindowEvents_WindowCreatedEventHandler WindowCreated;
	}
}
