using System.Collections;

namespace EnvDTE
{
    public interface ToolBoxTabs : IEnumerable
    {
        DTE DTE { get; }
        ToolBox Parent { get; }
        int Count { get; }
        new IEnumerator GetEnumerator();
        ToolBoxTab Item(object index);
        ToolBoxTab Add(string Name);
    }
}
