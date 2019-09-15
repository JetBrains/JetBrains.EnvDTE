using EnvDTE;

namespace EnvDTE80
{
    public interface ToolWindows
    {
        DTE DTE { get; }
        ToolBox ToolBox { get; }
        CommandWindow CommandWindow { get; }
        OutputWindow OutputWindow { get; }
        UIHierarchy SolutionExplorer { get; }
        TaskList TaskList { get; }
        ErrorList ErrorList { get; }
        object GetToolWindow(string Name);
    }
}
