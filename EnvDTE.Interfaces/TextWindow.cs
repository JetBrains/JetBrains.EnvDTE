namespace EnvDTE
{
    public interface TextWindow
    {
        DTE DTE { get; }
        Window Parent { get; }
        TextSelection Selection { get; }
        TextPane ActivePane { get; }
        TextPanes Panes { get; }
    }
}
