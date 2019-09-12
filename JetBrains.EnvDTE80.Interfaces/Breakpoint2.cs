
using EnvDTE;


namespace EnvDTE80
{
	public interface Breakpoint2 : Breakpoint
	{
		new dbgBreakpointType Type { get; }
		new string this[] { get; set; }
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
		Process2 Process { get; }
		bool BreakWhenHit { get; set; }
		string Message { get; set; }
		string Macro { get; set; }
		string FilterBy { get; set; }
		new void Delete();
		new void ResetHitCount();
	}
}
