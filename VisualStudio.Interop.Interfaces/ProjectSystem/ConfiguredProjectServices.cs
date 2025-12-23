using Microsoft.VisualStudio.ProjectSystem.Properties;

namespace Microsoft.VisualStudio.ProjectSystem;

public abstract class ConfiguredProjectServices
{
  public abstract IProjectPropertiesProvider? ProjectPropertiesProvider { get; }
}
