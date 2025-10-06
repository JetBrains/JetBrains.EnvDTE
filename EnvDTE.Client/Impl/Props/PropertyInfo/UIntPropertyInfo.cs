using System;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Props.PropertyInfo;

internal class UIntPropertyInfo([NotNull] string visualStudioName, [NotNull] string riderName, bool isReadOnly)
    : StringPropertyInfo(visualStudioName, riderName, isReadOnly)
{
    internal override object ParseValue(string value) => value is not null ? uint.Parse(value) : null;
}
