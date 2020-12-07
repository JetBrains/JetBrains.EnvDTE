namespace EnvDTE
{
    public class SolutionEventsClass : _SolutionEvents, SolutionEvents, _dispSolutionEvents_Event
    {
        public SolutionEventsClass(){}
        public virtual event _dispSolutionEvents_OpenedEventHandler Opened;
        public virtual event _dispSolutionEvents_BeforeClosingEventHandler BeforeClosing;
        public virtual event _dispSolutionEvents_AfterClosingEventHandler AfterClosing;
        public virtual event _dispSolutionEvents_QueryCloseSolutionEventHandler QueryCloseSolution;
        public virtual event _dispSolutionEvents_RenamedEventHandler Renamed;
        public virtual event _dispSolutionEvents_ProjectAddedEventHandler ProjectAdded;
        public virtual event _dispSolutionEvents_ProjectRemovedEventHandler ProjectRemoved;
        public virtual event _dispSolutionEvents_ProjectRenamedEventHandler ProjectRenamed;
    }
}
