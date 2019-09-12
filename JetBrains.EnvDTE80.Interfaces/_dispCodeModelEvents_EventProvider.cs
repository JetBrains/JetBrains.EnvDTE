using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;

namespace EnvDTE80
{
	internal sealed class _dispCodeModelEvents_EventProvider : _dispCodeModelEvents_Event, IDisposable
	{
		public _dispCodeModelEvents_EventProvider(object A_1)
		{
		}

		public event _dispCodeModelEvents_ElementAddedEventHandler ElementAdded;
		public event _dispCodeModelEvents_ElementChangedEventHandler ElementChanged;
		public event _dispCodeModelEvents_ElementDeletedEventHandler ElementDeleted;

		public void Dispose()
		{
		}

		public void Finalize()
		{
		}
	}
}
