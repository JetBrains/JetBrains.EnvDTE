using System.Collections;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.PropertiesImpl;

public abstract class PropertiesImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] object parent) : Properties
{
    protected readonly DteImplementation DteImplementation = dte;

    public object Application => null;
    public object Parent => parent;
    public DTE DTE => DteImplementation;

    public abstract int Count { get; }

    public abstract Property Item(object index);
    public abstract IEnumerator GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
