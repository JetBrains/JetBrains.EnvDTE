namespace EnvDTE
{
    public class TaskListEventsClass : _TaskListEvents, TaskListEvents, _dispTaskListEvents_Event
    {
        public TaskListEventsClass(){}
        public virtual event _dispTaskListEvents_TaskAddedEventHandler TaskAdded;
        public virtual event _dispTaskListEvents_TaskRemovedEventHandler TaskRemoved;
        public virtual event _dispTaskListEvents_TaskModifiedEventHandler TaskModified;
        public virtual event _dispTaskListEvents_TaskNavigatedEventHandler TaskNavigated;
    }
}
