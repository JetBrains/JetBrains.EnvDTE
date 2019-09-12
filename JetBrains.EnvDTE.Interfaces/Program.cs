namespace EnvDTE
{
	public interface Program
	{
		string this[] { get; }
		Process Process { get; }
		Threads Threads { get; }
		bool IsBeingDebugged { get; }
		DTE DTE { get; }
		Debugger Parent { get; }
		Programs Collection { get; }
	}
}
