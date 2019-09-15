using System.Collections;

namespace EnvDTE
{
    public interface Languages : IEnumerable
    {
        DTE DTE { get; }
        Debugger Parent { get; }
        int Count { get; }
        Language Item(object index);
        new IEnumerator GetEnumerator();
    }
}
