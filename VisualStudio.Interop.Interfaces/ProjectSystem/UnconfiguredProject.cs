using System.Threading.Tasks;

namespace Microsoft.VisualStudio.ProjectSystem;

public interface UnconfiguredProject
{
  Task<ConfiguredProject> GetSuggestedConfiguredProjectAsync();
}
