
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;


namespace EnvDTE80
{
	internal sealed class _dispTextDocumentKeyPressEvents_EventProvider : _dispTextDocumentKeyPressEvents_Event,
		IDisposable
	{
		private ArrayList m_aEventSinkHelpers;
		private UCOMIConnectionPoint m_ConnectionPoint;
		private readonly UCOMIConnectionPointContainer m_ConnectionPointContainer;

		public _dispTextDocumentKeyPressEvents_EventProvider(object A_1) =>
			m_ConnectionPointContainer = (UCOMIConnectionPointContainer) A_1;

		public void add_BeforeKeyPress(
			_dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispTextDocumentKeyPressEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_BeforeKeyPressDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_BeforeKeyPress(
			_dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler A_1)
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
					var aEventSinkHelper = (_dispTextDocumentKeyPressEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_BeforeKeyPressDelegate != null &&
					    ((aEventSinkHelper.m_BeforeKeyPressDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
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

		public void add_AfterKeyPress(
			_dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispTextDocumentKeyPressEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_AfterKeyPressDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_AfterKeyPress(
			_dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler A_1)
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
					var aEventSinkHelper = (_dispTextDocumentKeyPressEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_AfterKeyPressDelegate != null &&
					    ((aEventSinkHelper.m_AfterKeyPressDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
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
				(byte) 94,
				(byte) 200,
				(byte) 87,
				(byte) 75,
				(byte) 0,
				(byte) 81,
				(byte) 175,
				(byte) 76,
				(byte) 147,
				(byte) 1,
				(byte) 69,
				(byte) 68,
				(byte) 184,
				(byte) 92,
				(byte) 121,
				(byte) 69
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
						m_ConnectionPoint.Unadvise(((_dispTextDocumentKeyPressEvents_SinkHelper) m_aEventSinkHelpers)
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
