namespace EnvDTE
{
    public class OutputWindowEventsClass : _OutputWindowEvents, OutputWindowEvents, _dispOutputWindowEvents_Event
    {
        public OutputWindowEventsClass(){ }
        public virtual event _dispOutputWindowEvents_PaneAddedEventHandler PaneAdded;
        public virtual event _dispOutputWindowEvents_PaneUpdatedEventHandler PaneUpdated;
        public virtual event _dispOutputWindowEvents_PaneClearingEventHandler PaneClearing;
    }
}
