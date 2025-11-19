using JetBrains.EnvDTE.Client.Impl;
using JetBrains.Rider.Model;

namespace Microsoft.VisualStudio.ProjectSystem.Properties;

public class ProjectPropertiesProvider(DteImplementation dte, ProjectItemModel project) : IProjectPropertiesProvider
{
  private readonly ProjectProperties _properties = new(dte, project);

  public IProjectProperties GetCommonProperties() => _properties;
}
