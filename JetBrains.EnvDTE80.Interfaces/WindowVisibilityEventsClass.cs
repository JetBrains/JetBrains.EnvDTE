namespace EnvDTE80
{
	public class WindowVisibilityEventsClass : _WindowVisibilityEvents, WindowVisibilityEvents,
		_dispWindowVisibilityEvents_Event
	{
		public extern WindowVisibilityEventsClass();
		public virtual extern event _dispWindowVisibilityEvents_WindowHidingEventHandler WindowHiding;
		public virtual extern event _dispWindowVisibilityEvents_WindowShowingEventHandler WindowShowing;
	}
}
