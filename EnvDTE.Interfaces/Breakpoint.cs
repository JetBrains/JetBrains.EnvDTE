namespace EnvDTE
{
	public interface Breakpoint
	{
		dbgBreakpointType Type { get; }
		string Name { get; set; }
		dbgBreakpointLocationType LocationType { get; }
		string FunctionName { get; }
		int FunctionLineOffset { get; }
		int FunctionColumnOffset { get; }
		string File { get; }
		int FileLine { get; }
		int FileColumn { get; }
		dbgBreakpointConditionType ConditionType { get; }
		string Condition { get; }
		string Language { get; }
		dbgHitCountType HitCountType { get; }
		int HitCountTarget { get; }
		bool Enabled { get; set; }
		string Tag { get; set; }
		int CurrentHits { get; }
		Program Program { get; }
		DTE DTE { get; }
		Breakpoint Parent { get; }
		Breakpoints Collection { get; }
		Breakpoints Children { get; }
		void Delete();
		void ResetHitCount();
	}
}
