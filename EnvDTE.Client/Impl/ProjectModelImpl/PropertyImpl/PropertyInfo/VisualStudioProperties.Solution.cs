using System.Collections.Generic;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;

internal static partial class VisualStudioProperties
{
    // 'Extender', 'ExtenderCATID' and 'ExtenderNames' are not included
    internal static readonly IReadOnlyDictionary<string, StringPropertyInfo> SolutionPropertiesMap =
        new Dictionary<string, StringPropertyInfo>
        {
            ["ProjectDependencies"] = new ("ProjectDependencies", "ProjectDependencies", true),
            ["ActiveConfig"] = new ("ActiveConfig", "ActiveConfig", false),
            ["Path"] = new ("Path", "Path", true),
            ["Description"] = new ("Description", "Description", false),
            ["Name"] = new ("Name", "Name", false),
            ["StartupProject"] = new ("StartupProject", "StartupProject", false),
        };
}
