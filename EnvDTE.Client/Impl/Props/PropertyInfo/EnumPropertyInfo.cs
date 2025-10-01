using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Props.Exceptions;
using JetBrains.EnvDTE.Client.Util;

namespace JetBrains.EnvDTE.Client.Impl.Props.PropertyInfo;

internal class EnumPropertyInfo(
    [NotNull] string visualStudioName,
    [NotNull] string riderName,
    bool isReadOnly,
    [NotNull] ReadOnlyIndexedCanonicalSet<string> values)
    : StringPropertyInfo(visualStudioName, riderName, isReadOnly)
{
    // Enums are returned as strings in VS so we will not override the Parse method

    // Enum properties can be set in one of the following ways:
    // - string denoting the name of one of the valid values
    // - integer denoting the index of one of the
    // - `IEnumValue` TODO
    internal override string GetCanonicalValueOrThrow(object value)
    {
        if (value is int intValue)
        {
            if (intValue < 0 || intValue >= values.Count) throw new InvalidEnumPropertyValueException();
            return values.GetAt(intValue);
        }

        if (value is string stringValue)
        {
            if (!values.TryGetCanonical(stringValue, out var canonicalValue)) throw new InvalidEnumPropertyValueException();
            return canonicalValue;
        }

        throw new InvalidEnumPropertyValueException();
    }
}
