namespace EnvDTE
{
    public delegate void _dispDebuggerEvents_OnExceptionNotHandledEventHandler(
        string ExceptionType,
        string Name,
        int Code,
        string Description,
        ref dbgExceptionAction ExceptionAction);
}
