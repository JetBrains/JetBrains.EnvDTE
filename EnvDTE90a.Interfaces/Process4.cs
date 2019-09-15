using System;
using EnvDTE;
using EnvDTE80;
using EnvDTE90;

namespace EnvDTE90a
{
    public interface Process4 : Process3
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
        new Modules Modules { get; }
        Array EnvironmentVariables { get; }
        string CommandLine { get; }
        string CurrentDirectory { get; }
        new void Attach();
        new void Detach(bool WaitForBreakOrEnd = true);
        new void Break(bool WaitForBreakMode = true);
        new void Terminate(bool WaitForBreakOrEnd = true);
        new void Attach2(object Engines);
        new void Attach2();
    }
}
