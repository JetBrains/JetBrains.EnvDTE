using System.Collections;

namespace EnvDTE
{
    public interface OutputWindowPanes : IEnumerable
    {
        DTE DTE { get; }
        OutputWindow Parent { get; }
        int Count { get; }
        OutputWindowPane Add(string Name);
        OutputWindowPane Item(object index);
        new IEnumerator GetEnumerator();
    }
}
