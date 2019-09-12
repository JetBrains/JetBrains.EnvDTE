namespace EnvDTE
{
	public class SolutionEventsClass : _SolutionEvents, SolutionEvents, _dispSolutionEvents_Event
	{
		public extern SolutionEventsClass();
		public virtual extern event _dispSolutionEvents_OpenedEventHandler Opened;
		public virtual extern void add_Opened(_dispSolutionEvents_OpenedEventHandler A_1);
		public virtual extern void remove_Opened(_dispSolutionEvents_OpenedEventHandler A_1);
		public virtual extern event _dispSolutionEvents_BeforeClosingEventHandler BeforeClosing;
		public virtual extern void add_BeforeClosing(_dispSolutionEvents_BeforeClosingEventHandler A_1);

		public virtual extern void remove_BeforeClosing(
			_dispSolutionEvents_BeforeClosingEventHandler A_1);

		public virtual extern event _dispSolutionEvents_AfterClosingEventHandler AfterClosing;
		public virtual extern void add_AfterClosing(_dispSolutionEvents_AfterClosingEventHandler A_1);
		public virtual extern void remove_AfterClosing(_dispSolutionEvents_AfterClosingEventHandler A_1);

		public virtual extern void add_QueryCloseSolution(
			_dispSolutionEvents_QueryCloseSolutionEventHandler A_1);

		public virtual extern event _dispSolutionEvents_QueryCloseSolutionEventHandler QueryCloseSolution;

		public virtual extern void remove_QueryCloseSolution(
			_dispSolutionEvents_QueryCloseSolutionEventHandler A_1);

		public virtual extern event _dispSolutionEvents_RenamedEventHandler Renamed;
		public virtual extern void add_Renamed(_dispSolutionEvents_RenamedEventHandler A_1);
		public virtual extern void remove_Renamed(_dispSolutionEvents_RenamedEventHandler A_1);
		public virtual extern event _dispSolutionEvents_ProjectAddedEventHandler ProjectAdded;
		public virtual extern void add_ProjectAdded(_dispSolutionEvents_ProjectAddedEventHandler A_1);
		public virtual extern void remove_ProjectAdded(_dispSolutionEvents_ProjectAddedEventHandler A_1);
		public virtual extern event _dispSolutionEvents_ProjectRemovedEventHandler ProjectRemoved;
		public virtual extern void add_ProjectRemoved(_dispSolutionEvents_ProjectRemovedEventHandler A_1);

		public virtual extern void remove_ProjectRemoved(
			_dispSolutionEvents_ProjectRemovedEventHandler A_1);

		public virtual extern event _dispSolutionEvents_ProjectRenamedEventHandler ProjectRenamed;
		public virtual extern void add_ProjectRenamed(_dispSolutionEvents_ProjectRenamedEventHandler A_1);

		public virtual extern void remove_ProjectRenamed(
			_dispSolutionEvents_ProjectRenamedEventHandler A_1);
	}
}
