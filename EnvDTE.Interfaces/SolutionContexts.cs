using System.Collections;

namespace EnvDTE
{
    public interface SolutionContexts : IEnumerable
    {
        DTE DTE { get; }
        SolutionConfiguration Parent { get; }
        int Count { get; }
        new IEnumerator GetEnumerator();
        SolutionContext Item(object index);
    }
}
