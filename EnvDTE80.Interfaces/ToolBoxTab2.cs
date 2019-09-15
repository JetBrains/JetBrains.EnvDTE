using EnvDTE;

namespace EnvDTE80
{
    public interface ToolBoxTab2 : ToolBoxTab
    {
        new string Name { get; set; }
        new ToolBoxTabs Collection { get; }
        new DTE DTE { get; }
        new ToolBoxItems ToolBoxItems { get; }
        new bool ListView { get; set; }
        string UniqueID { get; set; }
        new void Activate();
        new void Delete();
    }
}
