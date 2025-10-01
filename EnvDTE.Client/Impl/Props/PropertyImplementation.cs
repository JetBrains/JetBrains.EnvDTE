using System;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Props.Exceptions;
using JetBrains.EnvDTE.Client.Impl.Props.PropertyInfo;

namespace JetBrains.EnvDTE.Client.Impl.Props;

// TODO: Add support for property of any type

public class PropertyImplementation : PropertyImplementationBase
{
    private readonly PropertyInfo.StringPropertyInfo _propertyInfo;
    private readonly Func<string, string> _getValue;
    private readonly Action<string, string> _setValue;

    internal PropertyImplementation(
        [NotNull] DteImplementation dte,
        [NotNull] PropertiesImplementation parent,
        [NotNull] PropertyInfo.StringPropertyInfo propertyInfo,
        [NotNull] Func<string, string> getValue,
        [NotNull] Action<string, string> setValue)
        : base(dte, parent, propertyInfo.VisualStudioName)
    {
        _propertyInfo = propertyInfo;
        _getValue = getValue;
        _setValue = setValue;
    }

    public override object Value
    {
        get => _propertyInfo.ParseValue(_getValue(_propertyInfo.RiderName));
        set
        {
            if (_propertyInfo.IsReadOnly) throw new SetReadOnlyPropertyException();

            var canonicalValue = _propertyInfo.GetCanonicalValueOrThrow(value);
            _setValue(_propertyInfo.RiderName, canonicalValue);
        }
    }
}
