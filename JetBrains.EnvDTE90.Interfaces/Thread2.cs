
using EnvDTE;


namespace EnvDTE90
{
	public interface Thread2 : Thread
	{
		new string this[] { get; }
		new int SuspendCount { get; }
		new int ID { get; }
		new StackFrames StackFrames { get; }
		new Program Program { get; }
		new bool IsAlive { get; }
		new string Priority { get; }
		new string Location { get; }
		new bool IsFrozen { get; }
		new DTE DTE { get; }
		new Debugger Parent { get; }
		new Threads Collection { get; }
		bool Flag { get; set; }
		string DisplayName { set; get; }
		enum_THREADCATEGORY Category { get; }
		new void Freeze();
		new void Thaw();
	}
}
