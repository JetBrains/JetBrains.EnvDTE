using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.PropertyImpl.PropertyInfo;

// By default, treat every property as a string property
public class StringPropertyInfo(
    [NotNull] string visualStudioName,
    [NotNull] string riderName,
    bool isReadOnly)
{
    internal string VisualStudioName { get; } = visualStudioName;
    internal string RiderName { get; } = riderName;
    internal bool IsReadOnly { get; } = isReadOnly;

    internal virtual string GetCanonicalValueOrThrow([CanBeNull] object value) => value?.ToString();
    internal virtual object ParseValue([CanBeNull] string value) => value;
}
