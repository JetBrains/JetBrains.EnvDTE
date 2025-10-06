using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.PropertiesImpl.PropertyInfo;

internal class IntPropertyInfo([NotNull] string visualStudioName, [NotNull] string riderName, bool isReadOnly)
    : StringPropertyInfo(visualStudioName, riderName, isReadOnly)
{
    internal override object ParseValue(string value) => value is not null ? int.Parse(value) : null;
}
