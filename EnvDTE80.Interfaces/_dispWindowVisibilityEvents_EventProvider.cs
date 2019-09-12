using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;

namespace EnvDTE80
{
	internal sealed class _dispWindowVisibilityEvents_EventProvider : _dispWindowVisibilityEvents_Event, IDisposable
	{
		public _dispWindowVisibilityEvents_EventProvider(object A_1)
		{
		}

		public event _dispWindowVisibilityEvents_WindowHidingEventHandler WindowHiding;
		public event _dispWindowVisibilityEvents_WindowShowingEventHandler WindowShowing;

		public void Dispose()
		{
		}

		public void Finalize()
		{
		}
	}
}
