using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.RdBackend.Common.Env;
using JetBrains.Rider.Backend.Env;
using JetBrains.Rider.Backend.Product;

namespace JetBrains.EnvDTE.Host;

[ZoneMarker]
// TODO: Rider backend zone?
public class ZoneMarker :  IRequire<IReSharperHostCoreFeatureZone>, IRequire<IRiderBackendFeatureZone>,
    IRequire<IProductWithRiderBackendEnvironmentZone>;
