using System;

namespace EnvDTE
{
	public sealed class _dispTaskListEvents_SinkHelper : _dispTaskListEvents
	{
		public int m_dwCookie;
		public _dispTaskListEvents_TaskAddedEventHandler m_TaskAddedDelegate;
		public _dispTaskListEvents_TaskModifiedEventHandler m_TaskModifiedDelegate;
		public _dispTaskListEvents_TaskNavigatedEventHandler m_TaskNavigatedDelegate;
		public _dispTaskListEvents_TaskRemovedEventHandler m_TaskRemovedDelegate;

		internal _dispTaskListEvents_SinkHelper()
		{
		}

		public void TaskAdded(TaskItem A_1)
		{
			throw new NotImplementedException();
		}

		public void TaskRemoved(TaskItem A_1)
		{
			throw new NotImplementedException();
		}

		public void TaskModified(TaskItem A_1, vsTaskListColumn A_2)
		{
			throw new NotImplementedException();
		}

		public void TaskNavigated(TaskItem A_1, ref bool A_2)
		{
			throw new NotImplementedException();
		}
	}
}
