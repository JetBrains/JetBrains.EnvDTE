namespace EnvDTE
{
	public interface Find
	{
		DTE DTE { get; }
		DTE Parent { get; }
		vsFindAction Action { get; set; }
		string FindWhat { get; set; }
		bool MatchCase { get; set; }
		bool MatchWholeWord { get; set; }
		bool MatchInHiddenText { get; set; }
		bool Backwards { get; set; }
		bool SearchSubfolders { get; set; }
		bool KeepModifiedDocumentsOpen { get; set; }
		vsFindPatternSyntax PatternSyntax { get; set; }
		string ReplaceWith { get; set; }
		vsFindTarget Target { get; set; }
		string SearchPath { get; set; }
		string FilesOfType { get; set; }
		vsFindResultsLocation ResultsLocation { get; set; }
		vsFindResult Execute();

		vsFindResult FindReplace(
			vsFindAction Action,
			string FindWhat,
			int vsFindOptionsValue = 0,
			string ReplaceWith = "",
			vsFindTarget Target = vsFindTarget.vsFindTargetCurrentDocument,
			string SearchPath = "",
			string FilesOfType = "",
			vsFindResultsLocation ResultsLocation = vsFindResultsLocation.vsFindResults1);
	}
}
