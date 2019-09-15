namespace EnvDTE
{
    public delegate void _dispDebuggerEvents_OnExceptionThrownEventHandler(
        string ExceptionType,
        string Name,
        int Code,
        string Description,
        ref dbgExceptionAction ExceptionAction);
}
