
using EnvDTE;


namespace EnvDTE80
{
	public interface Process2 : Process
	{
		new string Name { get; }
		new int ProcessID { get; }
		new Programs Programs { get; }
		new DTE DTE { get; }
		new Debugger Parent { get; }
		new Processes Collection { get; }
		Transport Transport { get; }
		string TransportQualifier { get; }
		Threads Threads { get; }
		bool IsBeingDebugged { get; }
		string UserName { get; }
		new void Attach();
		new void Detach(bool WaitForBreakOrEnd = true);
		new void Break(bool WaitForBreakMode = true);
		new void Terminate(bool WaitForBreakOrEnd = true);
		void Attach2(object Engines = "");
	}
}
