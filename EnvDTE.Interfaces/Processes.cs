using System.Collections;

namespace EnvDTE
{
    public interface Processes : IEnumerable
    {
        DTE DTE { get; }
        Debugger Parent { get; }
        int Count { get; }
        Process Item(object index);
        new IEnumerator GetEnumerator();
    }
}
