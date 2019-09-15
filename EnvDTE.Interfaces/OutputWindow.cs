namespace EnvDTE
{
    public interface OutputWindow
    {
        DTE DTE { get; }
        Window Parent { get; }
        OutputWindowPanes OutputWindowPanes { get; }
        OutputWindowPane ActivePane { get; }
    }
}
