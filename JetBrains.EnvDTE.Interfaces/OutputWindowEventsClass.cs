namespace EnvDTE
{
	public class OutputWindowEventsClass : _OutputWindowEvents, OutputWindowEvents, _dispOutputWindowEvents_Event
	{
		public extern OutputWindowEventsClass();
		public virtual extern event _dispOutputWindowEvents_PaneAddedEventHandler PaneAdded;
		public virtual extern void add_PaneAdded(_dispOutputWindowEvents_PaneAddedEventHandler A_1);
		public virtual extern void remove_PaneAdded(_dispOutputWindowEvents_PaneAddedEventHandler A_1);
		public virtual extern event _dispOutputWindowEvents_PaneUpdatedEventHandler PaneUpdated;

		public virtual extern void add_PaneUpdated(
			_dispOutputWindowEvents_PaneUpdatedEventHandler A_1);

		public virtual extern void remove_PaneUpdated(
			_dispOutputWindowEvents_PaneUpdatedEventHandler A_1);

		public virtual extern event _dispOutputWindowEvents_PaneClearingEventHandler PaneClearing;

		public virtual extern void add_PaneClearing(
			_dispOutputWindowEvents_PaneClearingEventHandler A_1);

		public virtual extern void remove_PaneClearing(
			_dispOutputWindowEvents_PaneClearingEventHandler A_1);
	}
}
