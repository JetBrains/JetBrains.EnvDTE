using System.Collections;

namespace EnvDTE
{
    public interface Expressions : IEnumerable
    {
        DTE DTE { get; }
        Debugger Parent { get; }
        int Count { get; }
        Expression Item(object index);
        new IEnumerator GetEnumerator();
    }
}
