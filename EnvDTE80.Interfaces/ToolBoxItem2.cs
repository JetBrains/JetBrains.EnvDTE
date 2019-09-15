using EnvDTE;

namespace EnvDTE80
{
    public interface ToolBoxItem2 : ToolBoxItem
    {
        new string Name { get; set; }
        new ToolBoxItems Collection { get; }
        new DTE DTE { get; }
        object Data { get; }
        new void Delete();
        new void Select();
    }
}
