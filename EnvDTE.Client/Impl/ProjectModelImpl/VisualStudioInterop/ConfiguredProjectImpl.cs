using JetBrains.EnvDTE.Client.Impl;
using JetBrains.Rider.Model;

namespace Microsoft.VisualStudio.ProjectSystem;

public sealed class ConfiguredProjectImpl(DteImplementation dte, ProjectItemModel project) : ConfiguredProject
{
  private readonly ConfiguredProjectServicesImpl _services = new(dte, project);

  public ConfiguredProjectServices Services => _services;
}
