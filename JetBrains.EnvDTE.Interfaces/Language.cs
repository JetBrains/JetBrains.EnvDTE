namespace EnvDTE
{
	public interface Language
	{
		string this[] { get; }
		DTE DTE { get; }
		Debugger Parent { get; }
		Languages Collection { get; }
	}
}
