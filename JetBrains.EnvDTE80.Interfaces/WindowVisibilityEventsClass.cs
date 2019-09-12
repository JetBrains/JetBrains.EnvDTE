namespace EnvDTE80
{
	public class WindowVisibilityEventsClass : _WindowVisibilityEvents, WindowVisibilityEvents,
		_dispWindowVisibilityEvents_Event
	{
		public extern WindowVisibilityEventsClass();
		public virtual extern event _dispWindowVisibilityEvents_WindowHidingEventHandler WindowHiding;

		public virtual extern void add_WindowHiding(
			_dispWindowVisibilityEvents_WindowHidingEventHandler A_1);

		public virtual extern void remove_WindowHiding(
			_dispWindowVisibilityEvents_WindowHidingEventHandler A_1);

		public virtual extern event _dispWindowVisibilityEvents_WindowShowingEventHandler WindowShowing;

		public virtual extern void add_WindowShowing(
			_dispWindowVisibilityEvents_WindowShowingEventHandler A_1);

		public virtual extern void remove_WindowShowing(
			_dispWindowVisibilityEvents_WindowShowingEventHandler A_1);
	}
}
