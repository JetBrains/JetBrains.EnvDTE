
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;


namespace EnvDTE80
{
	internal sealed class _dispPublishEvents_EventProvider : _dispPublishEvents_Event, IDisposable
	{
		private ArrayList m_aEventSinkHelpers;
		private UCOMIConnectionPoint m_ConnectionPoint;
		private readonly UCOMIConnectionPointContainer m_ConnectionPointContainer;

		public _dispPublishEvents_EventProvider(object A_1) =>
			m_ConnectionPointContainer = (UCOMIConnectionPointContainer) A_1;

		public void add_OnPublishBegin(_dispPublishEvents_OnPublishBeginEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispPublishEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_OnPublishBeginDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_OnPublishBegin(_dispPublishEvents_OnPublishBeginEventHandler A_1)
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
					var aEventSinkHelper = (_dispPublishEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_OnPublishBeginDelegate != null &&
					    ((aEventSinkHelper.m_OnPublishBeginDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
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

		public void add_OnPublishDone(_dispPublishEvents_OnPublishDoneEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispPublishEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_OnPublishDoneDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_OnPublishDone(_dispPublishEvents_OnPublishDoneEventHandler A_1)
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
					var aEventSinkHelper = (_dispPublishEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_OnPublishDoneDelegate != null &&
					    ((aEventSinkHelper.m_OnPublishDoneDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
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
				(byte) 147,
				(byte) 11,
				(byte) 180,
				(byte) 160,
				(byte) 17,
				(byte) 147,
				(byte) 15,
				(byte) 65,
				(byte) 178,
				(byte) 16,
				(byte) 31,
				(byte) 101,
				(byte) 186,
				(byte) 251,
				(byte) 14,
				(byte) 39
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
						m_ConnectionPoint.Unadvise(((_dispPublishEvents_SinkHelper) m_aEventSinkHelpers).m_dwCookie);
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
