
using System.Collections;


namespace EnvDTE
{
	public interface Breakpoints : IEnumerable
	{
		DTE DTE { get; }
		Debugger Parent { get; }
		int Count { get; }
		Breakpoint Item(object index);
		new IEnumerator GetEnumerator();

		Breakpoints Add(
			string Function = "",
			string File = "",
			int Line = 1,
			int Column = 1,
			string Condition = "",
			dbgBreakpointConditionType ConditionType = dbgBreakpointConditionType.dbgBreakpointConditionTypeWhenTrue,
			string Language = "",
			string Data = "",
			int DataCount = 1,
			string Address = "",
			int HitCount = 0,
			dbgHitCountType HitCountType = dbgHitCountType.dbgHitCountTypeNone);
	}
}
