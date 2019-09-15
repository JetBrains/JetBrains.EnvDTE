using EnvDTE;

namespace EnvDTE80
{
    public delegate void _dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler(
        Process pProcess,
        Thread Thread,
        dbgExpressionEvaluationState evaluationState);
}
