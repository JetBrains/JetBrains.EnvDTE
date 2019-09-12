namespace EnvDTE80
{
	public interface _dispDebuggerExpressionEvaluationEvents_Event
	{
		event _dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler OnExpressionEvaluation;

		void add_OnExpressionEvaluation(
			_dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler A_1);

		void remove_OnExpressionEvaluation(
			_dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler A_1);
	}
}
