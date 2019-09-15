using EnvDTE;
using EnvDTE80;

namespace EnvDTE90a
{
    public interface Breakpoint3 : Breakpoint2
    {
        new dbgBreakpointType Type { get; }
        new string Name { get; set; }
        new dbgBreakpointLocationType LocationType { get; }
        new string FunctionName { get; }
        new int FunctionLineOffset { get; }
        new int FunctionColumnOffset { get; }
        new string File { get; }
        new int FileLine { get; }
        new int FileColumn { get; }
        new dbgBreakpointConditionType ConditionType { get; }
        new string Condition { get; }
        new string Language { get; }
        new dbgHitCountType HitCountType { get; }
        new int HitCountTarget { get; }
        new bool Enabled { get; set; }
        new string Tag { get; set; }
        new int CurrentHits { get; }
        new Program Program { get; }
        new DTE DTE { get; }
        new Breakpoint Parent { get; }
        new Breakpoints Collection { get; }
        new Breakpoints Children { get; }
        new Process2 Process { get; }
        new bool BreakWhenHit { get; set; }
        new string Message { get; set; }
        new string Macro { get; set; }
        new string FilterBy { get; set; }
        string Address { get; }
        new void Delete();
        new void ResetHitCount();
    }
}
