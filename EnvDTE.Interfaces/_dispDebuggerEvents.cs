namespace EnvDTE
{
    public interface _dispDebuggerEvents
    {
        void OnEnterRunMode(dbgEventReason Reason);
        void OnEnterDesignMode(dbgEventReason Reason);
        void OnEnterBreakMode(dbgEventReason Reason, ref dbgExecutionAction ExecutionAction);

        void OnExceptionThrown(
            string ExceptionType,
            string Name,
            int Code,
            string Description,
            ref dbgExceptionAction ExceptionAction);

        void OnExceptionNotHandled(
            string ExceptionType,
            string Name,
            int Code,
            string Description,
            ref dbgExceptionAction ExceptionAction);

        void OnContextChanged(
            Process NewProcess,
            Program NewProgram,
            Thread NewThread,
            StackFrame NewStackFrame);
    }
}
