using EnvDTE;
using EnvDTE80;
using EnvDTE90;

namespace EnvDTE90a
{
    public interface Debugger4 : Debugger3
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
        new Transports Transports { get; }
        new bool ForceContinue { get; set; }
        new ExceptionGroups ExceptionGroups { get; }
        new string SymbolPath { get; }
        new string SymbolPathState { get; }
        new string SymbolCachePath { get; }
        new bool OnlyLoadSymbolsManually { get; }

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
        new void WriteMinidump(string FileName, dbgMinidumpOption Option);
        new Processes GetProcesses(Transport pTransport, string TransportQualifier);

        new Expression GetExpression2(
            string ExpressionText,
            bool UseAutoExpandRules = false,
            bool TreatAsStatement = false,
            int Timeout = -1);

        new void SetSymbolSettings(
            string SymbolPath,
            string SymbolPathState,
            string SymbolCachePath,
            bool OnlyLoadSymbolsManually,
            bool LoadSymbolsNow);

        Expression GetExpression3(
            string ExpressionText,
            StackFrame StackFrame = null,
            bool UseAutoExpandRules = false,
            bool TreatAsStatement = false,
            bool AllowAutoFuncEval = true,
            int Timeout = -1);
    }
}
