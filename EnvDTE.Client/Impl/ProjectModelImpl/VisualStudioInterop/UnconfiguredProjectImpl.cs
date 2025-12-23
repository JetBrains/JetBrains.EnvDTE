using System.Threading.Tasks;
using JetBrains.EnvDTE.Client.Impl;
using JetBrains.Rider.Model;

namespace Microsoft.VisualStudio.ProjectSystem;

public sealed class UnconfiguredProjectImpl(DteImplementation dte, ProjectItemModel project) : UnconfiguredProject
{
  private readonly ConfiguredProjectImpl _configuredProject = new(dte, project);

  public Task<ConfiguredProject> GetSuggestedConfiguredProjectAsync() => Task.FromResult<ConfiguredProject>(_configuredProject);
}
