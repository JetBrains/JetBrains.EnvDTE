
using EnvDTE;


namespace EnvDTE80
{
	public interface ErrorList
	{
		DTE DTE { get; }
		Window Parent { get; }
		bool ShowErrors { get; set; }
		bool ShowWarnings { get; set; }
		bool ShowMessages { get; set; }
		ErrorItems ErrorItems { get; }
		object SelectedItems { get; }
	}
}
