using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;

namespace EnvDTE
{
	internal sealed class _dispTaskListEvents_EventProvider : _dispTaskListEvents_Event, IDisposable
	{
		public _dispTaskListEvents_EventProvider(object A_1)
		{
		}

		public event _dispTaskListEvents_TaskAddedEventHandler TaskAdded;
		public event _dispTaskListEvents_TaskRemovedEventHandler TaskRemoved;
		public event _dispTaskListEvents_TaskModifiedEventHandler TaskModified;
		public event _dispTaskListEvents_TaskNavigatedEventHandler TaskNavigated;

		public void Dispose()
		{
		}

		public void Finalize()
		{
		}
	}
}
