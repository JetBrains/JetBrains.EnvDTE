using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class ProjectItemCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(ISolution solution, ProjectModelViewHost host, DteProtocolModel model)
        {
        }
    }
}
