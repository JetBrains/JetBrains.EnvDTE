namespace EnvDTE
{
	public interface _dispTaskListEvents_Event
	{
		event _dispTaskListEvents_TaskAddedEventHandler TaskAdded;
		event _dispTaskListEvents_TaskRemovedEventHandler TaskRemoved;
		event _dispTaskListEvents_TaskModifiedEventHandler TaskModified;
		event _dispTaskListEvents_TaskNavigatedEventHandler TaskNavigated;
	}
}
