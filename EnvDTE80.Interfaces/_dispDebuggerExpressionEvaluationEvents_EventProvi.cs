using System;

namespace EnvDTE80
{
    internal sealed class _dispDebuggerExpressionEvaluationEvents_EventProvider :
        _dispDebuggerExpressionEvaluationEvents_Event,
        IDisposable
    {
        public _dispDebuggerExpressionEvaluationEvents_EventProvider(object A_1)
        {
        }

        public event _dispDebuggerExpressionEvaluationEvents_OnExpressionEvaluationEventHandler OnExpressionEvaluation;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
