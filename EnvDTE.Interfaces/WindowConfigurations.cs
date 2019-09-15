using System.Collections;

namespace EnvDTE
{
    public interface WindowConfigurations : IEnumerable
    {
        DTE DTE { get; }
        DTE Parent { get; }
        int Count { get; }
        string ActiveConfigurationName { get; }
        new IEnumerator GetEnumerator();
        WindowConfiguration Item(object index);
        WindowConfiguration Add(string Name);
    }
}
