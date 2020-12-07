namespace EnvDTE
{
    public class WindowEventsClass : _WindowEvents, WindowEvents, _dispWindowEvents_Event
    {
        public WindowEventsClass(){ }
        public virtual event _dispWindowEvents_WindowClosingEventHandler WindowClosing;
        public virtual event _dispWindowEvents_WindowMovedEventHandler WindowMoved;
        public virtual event _dispWindowEvents_WindowActivatedEventHandler WindowActivated;
        public virtual event _dispWindowEvents_WindowCreatedEventHandler WindowCreated;
    }
}
