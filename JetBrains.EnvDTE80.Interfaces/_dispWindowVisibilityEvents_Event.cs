namespace EnvDTE80
{
	public interface _dispWindowVisibilityEvents_Event
	{
		event _dispWindowVisibilityEvents_WindowHidingEventHandler WindowHiding;

		void add_WindowHiding(
			_dispWindowVisibilityEvents_WindowHidingEventHandler A_1);

		void remove_WindowHiding(
			_dispWindowVisibilityEvents_WindowHidingEventHandler A_1);

		event _dispWindowVisibilityEvents_WindowShowingEventHandler WindowShowing;

		void add_WindowShowing(
			_dispWindowVisibilityEvents_WindowShowingEventHandler A_1);

		void remove_WindowShowing(
			_dispWindowVisibilityEvents_WindowShowingEventHandler A_1);
	}
}
