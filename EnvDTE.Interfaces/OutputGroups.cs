using System.Collections;

namespace EnvDTE
{
    public interface OutputGroups : IEnumerable
    {
        DTE DTE { get; }
        Configuration Parent { get; }
        int Count { get; }
        new IEnumerator GetEnumerator();
        OutputGroup Item(object index);
    }
}
