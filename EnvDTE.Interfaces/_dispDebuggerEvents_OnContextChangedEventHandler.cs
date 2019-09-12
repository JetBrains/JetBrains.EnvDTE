namespace EnvDTE
{
	public delegate void _dispDebuggerEvents_OnContextChangedEventHandler(
		Process NewProcess,
		Program NewProgram,
		Thread NewThread,
		StackFrame NewStackFrame);
}
