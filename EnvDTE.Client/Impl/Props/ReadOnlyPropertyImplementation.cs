using System;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Props;

public class ReadOnlyPropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] string key,
    [NotNull] Func<string> getValue)
    : PropertyImplementationBase(dte, parent, key)
{
    public override object Value
    {
        get => getValue();
        set => throw new InvalidOperationException("Can't set the value of a read-only property.");
    }
}
