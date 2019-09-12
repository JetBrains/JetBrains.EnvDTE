namespace EnvDTE
{
	public interface StackFrame
	{
		string Language { get; }
		string FunctionName { get; }
		string ReturnType { get; }
		Expressions Locals { get; }
		Expressions Arguments { get; }
		string Module { get; }
		DTE DTE { get; }
		Thread Parent { get; }
		StackFrames Collection { get; }
	}
}
