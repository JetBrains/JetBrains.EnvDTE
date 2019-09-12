
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;


namespace EnvDTE80
{
	internal sealed class
		_dispDebuggerExpressionEvaluationEvents_EventProvider : _dispDebuggerExpressionEvaluationEvents_Event,
			IDisposable
	{
		private ArrayList m_aEventSinkHelpers;
		private UCOMIConnectionPoint m_ConnectionPoint;
		private readonly UCOMIConnectionPointContainer m_ConnectionPointContainer;

		public _dispDebuggerExpressionEvaluationEvents_EventProvider(object A_1) =>
			m_ConnectionPointContainer = (UCOMIConnectionPointContainer) A_1;

		public void add_OnExpressionEvaluation(
			_dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler A_1)
		{
			Monitor.Enter(this);
			try
			{
				if (m_ConnectionPoint == null)
					Init();
				var eventsSinkHelper = new _dispDebuggerExpressionEvaluationEvents_SinkHelper();
				int pdwCookie = 0;
				m_ConnectionPoint.Advise(eventsSinkHelper, out pdwCookie);
				eventsSinkHelper.m_dwCookie = pdwCookie;
				eventsSinkHelper.m_OnExpressionEvaluationDelegate = A_1;
				m_aEventSinkHelpers.Add(eventsSinkHelper);
			}
			finally
			{
				Monitor.Exit(this);
			}
		}

		public void remove_OnExpressionEvaluation(
			_dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler A_1)
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
					var aEventSinkHelper = (_dispDebuggerExpressionEvaluationEvents_SinkHelper) m_aEventSinkHelpers;
					if (aEventSinkHelper.m_OnExpressionEvaluationDelegate != null &&
					    ((aEventSinkHelper.m_OnExpressionEvaluationDelegate.Equals(A_1) ? 1 : 0) & byte.MaxValue) != 0)
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
				(byte) 63, (byte) 161, byte.MaxValue, (byte) 115, (byte) 114, (byte) 173, (byte) 84, (byte) 65,
				(byte) 190, (byte) 119, (byte) 212, (byte) 40, (byte) 143, (byte) 46, (byte) 79, (byte) 197
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
						m_ConnectionPoint.Unadvise(
							((_dispDebuggerExpressionEvaluationEvents_SinkHelper) m_aEventSinkHelpers).m_dwCookie);
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
