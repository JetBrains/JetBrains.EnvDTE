
using EnvDTE;
using EnvDTE80;


namespace EnvDTE90
{
	public interface ToolBoxTab3 : ToolBoxTab2
	{
		new string Name { get; set; }
		new ToolBoxTabs Collection { get; }
		new DTE DTE { get; }
		new ToolBoxItems ToolBoxItems { get; }
		new bool ListView { get; set; }
		new string UniqueID { get; set; }
		bool Expanded { get; set; }
		new void Activate();
		new void Delete();
	}
}
