using EnvDTE;

namespace EnvDTE80
{
    public delegate void _dispDebuggerProcessEvents_OnProcessStateChangedEventHandler(
        Process NewProcess,
        dbgProcessState processState);
}
