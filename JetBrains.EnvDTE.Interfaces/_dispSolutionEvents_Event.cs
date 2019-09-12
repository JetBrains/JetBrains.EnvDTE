namespace EnvDTE
{
	public interface _dispSolutionEvents_Event
	{
		event _dispSolutionEvents_OpenedEventHandler Opened;
		event _dispSolutionEvents_BeforeClosingEventHandler BeforeClosing;
		event _dispSolutionEvents_AfterClosingEventHandler AfterClosing;
		event _dispSolutionEvents_QueryCloseSolutionEventHandler QueryCloseSolution;
		event _dispSolutionEvents_RenamedEventHandler Renamed;
		event _dispSolutionEvents_ProjectAddedEventHandler ProjectAdded;
		event _dispSolutionEvents_ProjectRemovedEventHandler ProjectRemoved;
		event _dispSolutionEvents_ProjectRenamedEventHandler ProjectRenamed;
	}
}
