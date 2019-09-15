namespace EnvDTE
{
    public interface Debugger
    {
        Breakpoints Breakpoints { get; }
        Languages Languages { get; }
        dbgDebugMode CurrentMode { get; }
        Process CurrentProcess { get; set; }
        Program CurrentProgram { get; set; }
        Thread CurrentThread { get; set; }
        StackFrame CurrentStackFrame { get; set; }
        bool HexDisplayMode { get; set; }
        bool HexInputMode { get; set; }
        dbgEventReason LastBreakReason { get; }
        Breakpoint BreakpointLastHit { get; }
        Breakpoints AllBreakpointsLastHit { get; }
        Processes DebuggedProcesses { get; }
        Processes LocalProcesses { get; }
        DTE DTE { get; }
        DTE Parent { get; }
        Expression GetExpression(string ExpressionText, bool UseAutoExpandRules = false, int Timeout = -1);
        void DetachAll();
        void StepInto(bool WaitForBreakOrEnd = true);
        void StepOver(bool WaitForBreakOrEnd = true);
        void StepOut(bool WaitForBreakOrEnd = true);
        void Go(bool WaitForBreakOrEnd = true);
        void Break(bool WaitForBreakMode = true);
        void Stop(bool WaitForDesignMode = true);
        void SetNextStatement();
        void RunToCursor(bool WaitForBreakOrEnd = true);
        void ExecuteStatement(string Statement, int Timeout = -1, bool TreatAsExpression = false);
        void TerminateAll();
    }
}
