namespace EnvDTE
{
	public interface OutputWindowPane
	{
		string Name { get; }
		DTE DTE { get; }
		OutputWindowPanes Collection { get; }
		string Guid { get; }
		TextDocument TextDocument { get; }
		void OutputString(string Text);
		void ForceItemsToTaskList();
		void Activate();
		void Clear();

		void OutputTaskItemString(
			string Text,
			vsTaskPriority Priority,
			string SubCategory,
			vsTaskIcon Icon,
			string FileName,
			int Line,
			string Description,
			bool Force = true);
	}
}
