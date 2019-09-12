namespace EnvDTE
{
	public delegate void _dispDebuggerEvents_OnEnterBreakModeEventHandler(
		dbgEventReason Reason,
		ref dbgExecutionAction ExecutionAction);
}
