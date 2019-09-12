namespace EnvDTE
{
	public interface ToolBoxTab
	{
		string this[] { get; set; }
		ToolBoxTabs Collection { get; }
		DTE DTE { get; }
		ToolBoxItems ToolBoxItems { get; }
		bool ListView { get; set; }
		void Activate();
		void Delete();
	}
}
