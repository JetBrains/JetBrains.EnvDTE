using System;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Props;

public class PropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] string key,
    [NotNull] Func<string> getValue,
    [NotNull] Action<string> setValue)
    : PropertyImplementationBase(dte, parent, key)
{
    public override object Value
    {
        get => getValue();
        set => setValue(value?.ToString());
    }
}
