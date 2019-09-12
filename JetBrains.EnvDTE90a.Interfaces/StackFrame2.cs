
using EnvDTE;


namespace EnvDTE90a
{
	public interface StackFrame2 : StackFrame
	{
		new string Language { get; }
		new string this[] { get; }
		new string ReturnType { get; }
		new Expressions Locals { get; }
		new Expressions Arguments { get; }
		new string Module { get; }
		new DTE DTE { get; }
		new Thread Parent { get; }
		new StackFrames Collection { get; }
		uint Depth { get; }
		bool UserCode { get; }
		uint LineNumber { get; }
		string FileName { get; }
		Expressions get_Locals2(bool AllowAutoFuncEval);
		Expressions get_Arguments2(bool AllowAutoFuncEval);
	}
}
