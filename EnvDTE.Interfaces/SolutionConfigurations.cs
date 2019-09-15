using System.Collections;

namespace EnvDTE
{
    public interface SolutionConfigurations : IEnumerable
    {
        DTE DTE { get; }
        SolutionBuild Parent { get; }
        int Count { get; }
        new IEnumerator GetEnumerator();
        SolutionConfiguration Item(object index);

        SolutionConfiguration Add(
            string NewName,
            string ExistingName,
            bool Propagate);
    }
}
