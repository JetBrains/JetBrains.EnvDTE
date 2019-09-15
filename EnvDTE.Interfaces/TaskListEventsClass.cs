namespace EnvDTE
{
    public class TaskListEventsClass : _TaskListEvents, TaskListEvents, _dispTaskListEvents_Event
    {
        public extern TaskListEventsClass();
        public virtual extern event _dispTaskListEvents_TaskAddedEventHandler TaskAdded;
        public virtual extern event _dispTaskListEvents_TaskRemovedEventHandler TaskRemoved;
        public virtual extern event _dispTaskListEvents_TaskModifiedEventHandler TaskModified;
        public virtual extern event _dispTaskListEvents_TaskNavigatedEventHandler TaskNavigated;
    }
}
