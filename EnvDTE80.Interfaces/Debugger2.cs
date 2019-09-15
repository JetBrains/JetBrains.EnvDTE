using EnvDTE;

namespace EnvDTE80
{
    public interface Debugger2 : Debugger
    {
        new Breakpoints Breakpoints { get; }
        new Languages Languages { get; }
        new dbgDebugMode CurrentMode { get; }
        new Process CurrentProcess { get; set; }
        new Program CurrentProgram { get; set; }
        new Thread CurrentThread { get; set; }
        new StackFrame CurrentStackFrame { get; set; }
        new bool HexDisplayMode { get; set; }
        new bool HexInputMode { get; set; }
        new dbgEventReason LastBreakReason { get; }
        new Breakpoint BreakpointLastHit { get; }
        new Breakpoints AllBreakpointsLastHit { get; }
        new Processes DebuggedProcesses { get; }
        new Processes LocalProcesses { get; }
        new DTE DTE { get; }
        new DTE Parent { get; }
        Transports Transports { get; }

        new Expression GetExpression(
            string ExpressionText,
            bool UseAutoExpandRules = false,
            int Timeout = -1);

        new void DetachAll();
        new void StepInto(bool WaitForBreakOrEnd = true);
        new void StepOver(bool WaitForBreakOrEnd = true);
        new void StepOut(bool WaitForBreakOrEnd = true);
        new void Go(bool WaitForBreakOrEnd = true);
        new void Break(bool WaitForBreakMode = true);
        new void Stop(bool WaitForDesignMode = true);
        new void SetNextStatement();
        new void RunToCursor(bool WaitForBreakOrEnd = true);
        new void ExecuteStatement(string Statement, int Timeout = -1, bool TreatAsExpression = false);
        new void TerminateAll();
        void WriteMinidump(string FileName, dbgMinidumpOption Option);
        Processes GetProcesses(Transport pTransport, string TransportQualifier);

        Expression GetExpression2(
            string ExpressionText,
            bool UseAutoExpandRules = false,
            bool TreatAsStatement = false,
            int Timeout = -1);
    }
}
