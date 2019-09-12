
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;


namespace EnvDTE
{
	internal sealed class _dispWindowEvents_EventProvider : _dispWindowEvents_Event, IDisposable
	{
		public _dispWindowEvents_EventProvider(object A_1)
		{
			
		}

		public event _dispWindowEvents_WindowClosingEventHandler WindowClosing;
		public event _dispWindowEvents_WindowMovedEventHandler WindowMoved;
		public event _dispWindowEvents_WindowActivatedEventHandler WindowActivated;
		public event _dispWindowEvents_WindowCreatedEventHandler WindowCreated;

		public void Dispose()
		{
		}


		public void Finalize()
		{
		}
	}
}
