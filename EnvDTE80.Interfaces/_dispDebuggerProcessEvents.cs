using EnvDTE;

namespace EnvDTE80
{
    public interface _dispDebuggerProcessEvents
    {
        void OnProcessStateChanged(Process NewProcess, dbgProcessState processState);
    }
}
