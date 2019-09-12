namespace EnvDTE
{
	public class SolutionEventsClass : _SolutionEvents, SolutionEvents, _dispSolutionEvents_Event
	{
		public extern SolutionEventsClass();
		public virtual extern event _dispSolutionEvents_OpenedEventHandler Opened;
		public virtual extern event _dispSolutionEvents_BeforeClosingEventHandler BeforeClosing;
		public virtual extern event _dispSolutionEvents_AfterClosingEventHandler AfterClosing;
		public virtual extern event _dispSolutionEvents_QueryCloseSolutionEventHandler QueryCloseSolution;
		public virtual extern event _dispSolutionEvents_RenamedEventHandler Renamed;
		public virtual extern event _dispSolutionEvents_ProjectAddedEventHandler ProjectAdded;
		public virtual extern event _dispSolutionEvents_ProjectRemovedEventHandler ProjectRemoved;
		public virtual extern event _dispSolutionEvents_ProjectRenamedEventHandler ProjectRenamed;
	}
}
