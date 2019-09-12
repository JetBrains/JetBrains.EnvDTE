
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;


namespace EnvDTE80
{
	internal sealed class _dispCodeModelEvents_EventProvider : _dispCodeModelEvents_Event, IDisposable
	{
		private ArrayList m_aEventSinkHelpers;
		private UCOMIConnectionPoint m_ConnectionPoint;
		private readonly UCOMIConnectionPointContainer m_ConnectionPointContainer;

		public _dispCodeModelEvents_EventProvider(object A_1) =>
			m_ConnectionPointContainer = (UCOMIConnectionPointContainer) A_1;

		public void add_ElementAdded(_dispCodeModelEvents_ElementAddedEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispCodeModelEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_ElementAddedDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_ElementAdded(_dispCodeModelEvents_ElementAddedEventHandler A_1)
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
					var aEventSinkHelper = (_dispCodeModelEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_ElementAddedDelegate != null &&
					    ((aEventSinkHelper.m_ElementAddedDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
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

		public void add_ElementChanged(
			_dispCodeModelEvents_ElementChangedEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispCodeModelEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_ElementChangedDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_ElementChanged(
			_dispCodeModelEvents_ElementChangedEventHandler A_1)
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
					var aEventSinkHelper = (_dispCodeModelEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_ElementChangedDelegate != null &&
					    ((aEventSinkHelper.m_ElementChangedDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
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

		public void add_ElementDeleted(
			_dispCodeModelEvents_ElementDeletedEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispCodeModelEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_ElementDeletedDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_ElementDeleted(
			_dispCodeModelEvents_ElementDeletedEventHandler A_1)
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
					var aEventSinkHelper = (_dispCodeModelEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_ElementDeletedDelegate != null &&
					    ((aEventSinkHelper.m_ElementDeletedDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
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
				(byte) 14,
				(byte) 9,
				(byte) 168,
				(byte) 78,
				(byte) 137,
				(byte) 210,
				(byte) 86,
				(byte) 77,
				(byte) 152,
				(byte) 205,
				(byte) 196,
				(byte) 141,
				(byte) 210,
				(byte) 133,
				(byte) 59,
				(byte) 46
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
						m_ConnectionPoint.Unadvise(((_dispCodeModelEvents_SinkHelper) m_aEventSinkHelpers).m_dwCookie);
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
