namespace EnvDTE
{
	public interface TextRange
	{
		DTE DTE { get; }
		TextRanges Collection { get; }
		EditPoint StartPoint { get; }
		EditPoint EndPoint { get; }
	}
}
