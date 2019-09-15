namespace EnvDTE
{
    public interface ColorableItems
    {
        string Name { get; }
        uint Foreground { get; set; }
        uint Background { get; set; }
        bool Bold { get; set; }
    }
}
