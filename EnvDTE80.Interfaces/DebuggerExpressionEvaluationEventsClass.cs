namespace EnvDTE80
{
    public class DebuggerExpressionEvaluationEventsClass : _DebuggerExpressionEvaluationEvents,
        DebuggerExpressionEvaluationEvents, _dispDebuggerExpressionEvaluationEvents_Event
    {
        public DebuggerExpressionEvaluationEventsClass(){ }

        public virtual event _dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler
            OnExpressionEvaluation;
    }
}
