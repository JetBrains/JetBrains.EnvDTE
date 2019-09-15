namespace EnvDTE
{
    public interface Language
    {
        string Name { get; }
        DTE DTE { get; }
        Debugger Parent { get; }
        Languages Collection { get; }
    }
}
