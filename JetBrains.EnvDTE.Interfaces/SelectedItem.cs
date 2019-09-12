namespace EnvDTE
{
	public interface SelectedItem
	{
		SelectedItems Collection { get; }
		DTE DTE { get; }
		Project Project { get; }
		ProjectItem ProjectItem { get; }
		string this[] { get; }
		short InfoCount { get; }
		object get_Info(short index);
	}
}
