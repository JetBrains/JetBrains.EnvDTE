namespace EnvDTE80
{
	public class DebuggerExpressionEvaluationEventsClass : _DebuggerExpressionEvaluationEvents,
		DebuggerExpressionEvaluationEvents, _dispDebuggerExpressionEvaluationEvents_Event
	{
		public extern DebuggerExpressionEvaluationEventsClass();

		public virtual extern event _dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler
			OnExpressionEvaluation;
	}
}
