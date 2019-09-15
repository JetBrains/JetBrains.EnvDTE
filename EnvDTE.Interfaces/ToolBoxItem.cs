namespace EnvDTE
{
    public interface ToolBoxItem
    {
        string Name { get; set; }
        ToolBoxItems Collection { get; }
        DTE DTE { get; }
        void Delete();
        void Select();
    }
}
