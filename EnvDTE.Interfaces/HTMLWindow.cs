namespace EnvDTE
{
    public interface HTMLWindow
    {
        DTE DTE { get; }
        Window Parent { get; }
        vsHTMLTabs CurrentTab { get; set; }
        object CurrentTabObject { get; }
    }
}
