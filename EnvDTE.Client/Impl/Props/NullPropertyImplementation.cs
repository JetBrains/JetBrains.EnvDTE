using System;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Props;

public class NullPropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] string key)
    : PropertyImplementationBase(dte, parent, key)
{
    public override object Value
    {
        get => null;
        set => throw new InvalidOperationException();
    }
}
