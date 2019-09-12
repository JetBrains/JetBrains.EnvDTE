namespace EnvDTE
{
	public interface TaskList
	{
		DTE DTE { get; }
		Window Parent { get; }
		string DefaultCommentToken { get; }
		TaskItems TaskItems { get; }
		object SelectedItems { get; }
	}
}
