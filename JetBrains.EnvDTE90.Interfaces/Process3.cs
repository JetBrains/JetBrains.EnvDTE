
using EnvDTE;
using EnvDTE80;


namespace EnvDTE90
{
	public interface Process3 : Process2
	{
		new string Name { get; }
		new int ProcessID { get; }
		new Programs Programs { get; }
		new DTE DTE { get; }
		new Debugger Parent { get; }
		new Processes Collection { get; }
		new Transport Transport { get; }
		new string TransportQualifier { get; }
		new Threads Threads { get; }
		new bool IsBeingDebugged { get; }
		new string UserName { get; }
		Modules Modules { get; }
		new void Attach();
		new void Detach(bool WaitForBreakOrEnd = true);
		new void Break(bool WaitForBreakMode = true);
		new void Terminate(bool WaitForBreakOrEnd = true);
		new void Attach2(object Engines = "");
	}
}
