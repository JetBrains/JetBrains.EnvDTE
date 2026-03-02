using System.Collections.Generic;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;

internal static partial class VisualStudioProperties
{
    // TODO: Implement this fully
    internal static readonly IReadOnlyDictionary<string, StringPropertyInfo> ProjectItemPropertiesMap =
        new Dictionary<string, StringPropertyInfo>
        {
            ["FullPath"] = new("FullPath", "FullPath", true)
        };
}
