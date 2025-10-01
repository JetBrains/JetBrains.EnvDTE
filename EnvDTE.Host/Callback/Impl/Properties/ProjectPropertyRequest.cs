using System.Collections.Generic;
using JetBrains.Application;
using JetBrains.Application.Parts;
using JetBrains.ProjectModel.MSBuild;
using JetBrains.ProjectModel.Properties;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Properties;

// For some reason, these two are not readable through `IMsBuildPropertiesEditor`
// I suspect that it is because they are computed based on other properties, and are not actual MSBuild properties
// TODO: Investigate
[ShellComponent(Instantiation.DemandAnyThreadSafe)]
public class EnvDteProjectPropertyRequest : IProjectPropertiesRequest
{
    public IEnumerable<string> RequestedProperties => [
        "TargetFileName",
        MSBuildProjectUtil.TargetFrameworkMonikerProperty,
    ];
}
