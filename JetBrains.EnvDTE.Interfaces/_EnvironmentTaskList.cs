namespace EnvDTE
{
	public interface _EnvironmentTaskList
	{
		bool ConfirmTaskDeletion { get; set; }
		bool WarnOnAddingHiddenItem { get; set; }
		object CommentTokens { get; set; }
	}
}
