using JetBrains.EnvDTE.Client.Impl;
using JetBrains.Rider.Model;
using Microsoft.VisualStudio.ProjectSystem.Properties;

namespace Microsoft.VisualStudio.ProjectSystem;

public class ConfiguredProjectServicesImpl(DteImplementation dte, ProjectItemModel project) : ConfiguredProjectServices
{
  public override IProjectPropertiesProvider ProjectPropertiesProvider { get; } =
      new ProjectPropertiesProvider(dte, project);
}
