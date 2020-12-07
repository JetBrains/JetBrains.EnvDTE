namespace EnvDTE80
{
    public class WindowVisibilityEventsClass : _WindowVisibilityEvents, WindowVisibilityEvents,
        _dispWindowVisibilityEvents_Event
    {
        public WindowVisibilityEventsClass(){ }
        public virtual event _dispWindowVisibilityEvents_WindowHidingEventHandler WindowHiding;
        public virtual event _dispWindowVisibilityEvents_WindowShowingEventHandler WindowShowing;
    }
}
