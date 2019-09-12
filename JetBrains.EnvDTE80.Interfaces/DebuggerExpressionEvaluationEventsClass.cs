namespace EnvDTE80
{
	public class DebuggerExpressionEvaluationEventsClass : _DebuggerExpressionEvaluationEvents,
		DebuggerExpressionEvaluationEvents, _dispDebuggerExpressionEvaluationEvents_Event
	{
		public extern DebuggerExpressionEvaluationEventsClass();

		public virtual extern event _dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler
			OnExpressionEvaluation;

		public virtual extern void add_OnExpressionEvaluation(
			_dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler A_1);

		public virtual extern void remove_OnExpressionEvaluation(
			_dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler A_1);
	}
}
