using System;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.PropertyImpl.PropertyInfo;

public class DynamicEnumPropertyInfo([NotNull] string visualStudioName, [NotNull] string riderName, bool isReadOnly)
    : StringPropertyInfo(visualStudioName, riderName, isReadOnly)
{
    internal override string GetCanonicalValueOrThrow(object value) => throw new NotImplementedException();
    internal override object ParseValue(string value) => throw new NotImplementedException();
}
