using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.PropertiesImpl.PropertyInfo;

internal class BoolPropertyInfo([NotNull] string visualStudioName, [NotNull] string riderName, bool isReadOnly)
    : StringPropertyInfo(visualStudioName, riderName, isReadOnly)
{
    internal override object ParseValue(string value) => value is not null ? bool.Parse(value) : null;
}
