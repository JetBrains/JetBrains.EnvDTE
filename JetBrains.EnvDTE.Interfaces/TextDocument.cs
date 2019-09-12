namespace EnvDTE
{
	public interface TextDocument
	{
		DTE DTE { get; }
		Document Parent { get; }
		TextSelection Selection { get; }
		TextPoint StartPoint { get; }
		TextPoint EndPoint { get; }
		string Language { get; set; }
		string Type { get; }
		int IndentSize { get; }
		int TabSize { get; }
		void ClearBookmarks();
		bool MarkText(string Pattern, int vsFindOptionsValue = 0);

		bool ReplacePattern(
			string Pattern,
			string Replace,
			int vsFindOptionsValue = 0,
			TextRanges Tags = null);

		EditPoint CreateEditPoint(TextPoint TextPoint = null);
		bool ReplaceText(string FindText, string ReplaceText, int vsFindOptionsValue = 0);
		void PrintOut();
	}
}
