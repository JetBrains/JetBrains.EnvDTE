using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost;

namespace JetBrains.EnvDTE.Host;

[ZoneMarker]
public class ZoneMarker : IRequire<IHostSolutionZone>;
