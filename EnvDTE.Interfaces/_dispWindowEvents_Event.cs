namespace EnvDTE
{
    public interface _dispWindowEvents_Event
    {
        event _dispWindowEvents_WindowClosingEventHandler WindowClosing;
        event _dispWindowEvents_WindowMovedEventHandler WindowMoved;
        event _dispWindowEvents_WindowActivatedEventHandler WindowActivated;
        event _dispWindowEvents_WindowCreatedEventHandler WindowCreated;
    }
}
