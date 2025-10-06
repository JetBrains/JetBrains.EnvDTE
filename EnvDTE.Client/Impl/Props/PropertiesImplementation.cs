using System.Collections;
using JetBrains.Annotations;
using EnvDTE;

namespace JetBrains.EnvDTE.Client.Impl.Props;

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
