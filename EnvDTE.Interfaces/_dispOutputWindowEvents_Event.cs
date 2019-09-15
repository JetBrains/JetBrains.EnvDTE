namespace EnvDTE
{
    public interface _dispOutputWindowEvents_Event
    {
        event _dispOutputWindowEvents_PaneAddedEventHandler PaneAdded;
        event _dispOutputWindowEvents_PaneUpdatedEventHandler PaneUpdated;
        event _dispOutputWindowEvents_PaneClearingEventHandler PaneClearing;
    }
}
