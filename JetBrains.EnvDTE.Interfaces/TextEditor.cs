namespace EnvDTE
{
	public interface TextEditor
	{
		DTE Application { get; }
		DTE Parent { get; }
		int Emulation { get; set; }
		bool Overtype { get; set; }
		bool VisibleWhitespace { get; set; }
	}
}
