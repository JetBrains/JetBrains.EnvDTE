using System.Collections;

namespace EnvDTE
{
    public interface Properties : IEnumerable
    {
        object Application { get; }
        object Parent { get; }
        int Count { get; }
        DTE DTE { get; }
        Property Item(object index);
        new IEnumerator GetEnumerator();
    }
}
