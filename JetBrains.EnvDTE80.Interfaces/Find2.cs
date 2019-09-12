
using EnvDTE;


namespace EnvDTE80
{
	public interface Find2 : Find
	{
		new DTE DTE { get; }
		new DTE Parent { get; }
		new vsFindAction Action { get; set; }
		new string FindWhat { get; set; }
		new bool MatchCase { get; set; }
		new bool MatchWholeWord { get; set; }
		new bool MatchInHiddenText { get; set; }
		new bool Backwards { get; set; }
		new bool SearchSubfolders { get; set; }
		new bool KeepModifiedDocumentsOpen { get; set; }
		new vsFindPatternSyntax PatternSyntax { get; set; }
		new string ReplaceWith { get; set; }
		new vsFindTarget Target { get; set; }
		new string SearchPath { get; set; }
		new string FilesOfType { get; set; }
		new vsFindResultsLocation ResultsLocation { get; set; }
		bool WaitForFindToComplete { get; set; }
		new vsFindResult Execute();

		new vsFindResult FindReplace(
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
