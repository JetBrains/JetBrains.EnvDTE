using System.Collections;
using EnvDTE;

namespace EnvDTE90
{
    public interface Modules : IEnumerable
    {
        DTE DTE { get; }
        Debugger Parent { get; }
        int Count { get; }
        Module Item(object Index);
        new IEnumerator GetEnumerator();
    }
}
