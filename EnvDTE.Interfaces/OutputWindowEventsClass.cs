namespace EnvDTE
{
    public class OutputWindowEventsClass : _OutputWindowEvents, OutputWindowEvents, _dispOutputWindowEvents_Event
    {
        public extern OutputWindowEventsClass();
        public virtual extern event _dispOutputWindowEvents_PaneAddedEventHandler PaneAdded;
        public virtual extern event _dispOutputWindowEvents_PaneUpdatedEventHandler PaneUpdated;
        public virtual extern event _dispOutputWindowEvents_PaneClearingEventHandler PaneClearing;
    }
}
