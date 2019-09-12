
using EnvDTE;


namespace EnvDTE80
{
	public interface _dispDebuggerExpressionEvaluationEvents
	{
		void OnExpressionEvaluation(
			Process pProcess,
			Thread Thread,
			dbgExpressionEvaluationState evaluationState);
	}
}
