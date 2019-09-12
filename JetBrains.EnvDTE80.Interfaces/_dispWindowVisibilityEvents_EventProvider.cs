
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;


namespace EnvDTE80
{
	internal sealed class _dispWindowVisibilityEvents_EventProvider : _dispWindowVisibilityEvents_Event, IDisposable
	{
		private ArrayList m_aEventSinkHelpers;
		private UCOMIConnectionPoint m_ConnectionPoint;
		private readonly UCOMIConnectionPointContainer m_ConnectionPointContainer;

		public _dispWindowVisibilityEvents_EventProvider(object A_1) =>
			m_ConnectionPointContainer = (UCOMIConnectionPointContainer) A_1;

		public void add_WindowHiding(
			_dispWindowVisibilityEvents_WindowHidingEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispWindowVisibilityEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_WindowHidingDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_WindowHiding(
			_dispWindowVisibilityEvents_WindowHidingEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_aEventSinkHelpers == null)
					return;
				int count = m_aEventSinkHelpers.Count;
				int index = 0;
				if (0 >= count)
					return;
				do
				{
					var aEventSinkHelper = (_dispWindowVisibilityEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_WindowHidingDelegate != null &&
					    ((aEventSinkHelper.m_WindowHidingDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
					{
						m_aEventSinkHelpers.RemoveAt(index);
						m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
						if (count <= 1)
						{
							Marshal.ReleaseComObject(m_ConnectionPoint);
							m_ConnectionPoint = null;
							m_aEventSinkHelpers = null;
							return;
						}

						goto label_10;
					}
					else
						++index;
				}
				while (index < count);

				goto label_11;
				label_10:
				return;
				label_11: ;
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void add_WindowShowing(
			_dispWindowVisibilityEvents_WindowShowingEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispWindowVisibilityEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_WindowShowingDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_WindowShowing(
			_dispWindowVisibilityEvents_WindowShowingEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_aEventSinkHelpers == null)
					return;
				int count = m_aEventSinkHelpers.Count;
				int index = 0;
				if (0 >= count)
					return;
				do
				{
					var aEventSinkHelper = (_dispWindowVisibilityEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_WindowShowingDelegate != null &&
					    ((aEventSinkHelper.m_WindowShowingDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
					{
						m_aEventSinkHelpers.RemoveAt(index);
						m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
						if (count <= 1)
						{
							Marshal.ReleaseComObject(m_ConnectionPoint);
							m_ConnectionPoint = null;
							m_aEventSinkHelpers = null;
							return;
						}

						goto label_10;
					}
					else
						++index;
				}
				while (index < count);

				goto label_11;
				label_10:
				return;
				label_11: ;
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void Dispose()
		{
			this.Finalize();
			GC.SuppressFinalize(this);
		}

		private void Init()
		{
			var ppCP = (UCOMIConnectionPoint) null;
			var riid = new Guid(new byte
			{
				(byte) 75,
				(byte) 158,
				(byte) 37,
				(byte) 148,
				(byte) 74,
				(byte) 164,
				(byte) 119,
				(byte) 75,
				(byte) 177,
				(byte) 143,
				(byte) 242,
				(byte) 204,
				(byte) 154,
				(byte) 96,
				(byte) 29,
				(byte) 3
			});
			m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
			m_ConnectionPoint = ppCP;
			m_aEventSinkHelpers = new ArrayList();
		}

		public override void Finalize()
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					return;
				int count = m_aEventSinkHelpers.Count;
				int index = 0;
				if (0 < count)
					do
					{
						m_ConnectionPoint.Unadvise(((_dispWindowVisibilityEvents_SinkHelper) m_aEventSinkHelpers)
							.m_dwCookie);
						++index;
					}
					while (index < count);

				Marshal.ReleaseComObject(m_ConnectionPoint);
			}
			catch (Exception ex)
			{
			}
			finally
			{
				Monitor.Exit(this);
			}
		}
	}
}
