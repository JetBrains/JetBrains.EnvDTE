using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.Rider.Backend.Env;
using JetBrains.Rider.Backend.Product;

namespace JetBrains.EnvDTE.Host;

[ZoneMarker]
public class ZoneMarker : IRequire<IRiderBackendFeatureZone>, IRequire<IProductWithRiderBackendEnvironmentZone>;
