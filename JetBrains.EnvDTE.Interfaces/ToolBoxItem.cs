namespace EnvDTE
{
	public interface ToolBoxItem
	{
		string this[] { get; set; }
		ToolBoxItems Collection { get; }
		DTE DTE { get; }
		void Delete();
		void Select();
	}
}
