using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.RdBackend.Common.Env;

namespace JetBrains.EnvDTE.Host;

[ZoneMarker]
public class ZoneMarker :  IRequire<IReSharperHostCoreFeatureZone>;
