namespace EnvDTE
{
	public interface ToolBox
	{
		DTE DTE { get; }
		Window Parent { get; }
		ToolBoxTab ActiveTab { get; }
		ToolBoxTabs ToolBoxTabs { get; }
	}
}
