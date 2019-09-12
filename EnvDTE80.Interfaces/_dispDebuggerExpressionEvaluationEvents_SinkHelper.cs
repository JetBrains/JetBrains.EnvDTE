
using EnvDTE;


namespace EnvDTE80
{
	public sealed class _dispDebuggerExpressionEvaluationEvents_SinkHelper : _dispDebuggerExpressionEvaluationEvents
	{
		public int m_dwCookie;

		public _dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler
			m_OnExpressionEvaluationDelegate;

		internal _dispDebuggerExpressionEvaluationEvents_SinkHelper()
		{
			m_dwCookie = 0;
			m_OnExpressionEvaluationDelegate = null;
		}

		public void OnExpressionEvaluation(
			Process A_1,
			Thread A_2,
			dbgExpressionEvaluationState A_3)
		{
			if (m_OnExpressionEvaluationDelegate == null)
				return;
			m_OnExpressionEvaluationDelegate(A_1, A_2, A_3);
		}
	}
}
