namespace EnvDTE
{
	public class TaskListEventsClass : _TaskListEvents, TaskListEvents, _dispTaskListEvents_Event
	{
		public extern TaskListEventsClass();
		public virtual extern event _dispTaskListEvents_TaskAddedEventHandler TaskAdded;
		public virtual extern void add_TaskAdded(_dispTaskListEvents_TaskAddedEventHandler A_1);
		public virtual extern void remove_TaskAdded(_dispTaskListEvents_TaskAddedEventHandler A_1);
		public virtual extern event _dispTaskListEvents_TaskRemovedEventHandler TaskRemoved;
		public virtual extern void add_TaskRemoved(_dispTaskListEvents_TaskRemovedEventHandler A_1);
		public virtual extern void remove_TaskRemoved(_dispTaskListEvents_TaskRemovedEventHandler A_1);
		public virtual extern event _dispTaskListEvents_TaskModifiedEventHandler TaskModified;
		public virtual extern void add_TaskModified(_dispTaskListEvents_TaskModifiedEventHandler A_1);
		public virtual extern void remove_TaskModified(_dispTaskListEvents_TaskModifiedEventHandler A_1);
		public virtual extern event _dispTaskListEvents_TaskNavigatedEventHandler TaskNavigated;
		public virtual extern void add_TaskNavigated(_dispTaskListEvents_TaskNavigatedEventHandler A_1);

		public virtual extern void remove_TaskNavigated(
			_dispTaskListEvents_TaskNavigatedEventHandler A_1);
	}
}
