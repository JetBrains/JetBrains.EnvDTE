namespace EnvDTE
{
	public interface Thread
	{
		string Name { get; }
		int SuspendCount { get; }
		int ID { get; }
		StackFrames StackFrames { get; }
		Program Program { get; }
		bool IsAlive { get; }
		string Priority { get; }
		string Location { get; }
		bool IsFrozen { get; }
		DTE DTE { get; }
		Debugger Parent { get; }
		Threads Collection { get; }
		void Freeze();
		void Thaw();
	}
}
