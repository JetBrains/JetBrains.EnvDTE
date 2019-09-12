namespace EnvDTE
{
	public interface Process
	{
		string Name { get; }
		int ProcessID { get; }
		Programs Programs { get; }
		DTE DTE { get; }
		Debugger Parent { get; }
		Processes Collection { get; }
		void Attach();
		void Detach(bool WaitForBreakOrEnd = true);
		void Break(bool WaitForBreakMode = true);
		void Terminate(bool WaitForBreakOrEnd = true);
	}
}
