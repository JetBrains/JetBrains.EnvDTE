using System.Linq;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class SolutionCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            ConnectionManager manager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            model.Solution_FileName.SetWithReadLock(() => solution.SolutionFilePath.FullPath);
            model.Solution_Count.SetWithReadLock(() => solution.GetAllProjects().Count);
            model.Solution_Item.SetWithReadLock(index =>
            {
                var projects = solution.GetAllProjects();
                if (projects.Count >= index) return new Rider.Model.ProjectModel(-1);
                var project = projects.ElementAt(index + 1);
                int id = host.GetIdByItem(project);
                return new Rider.Model.ProjectModel(id);
            });
            model.Solution_get_Projects.SetWithReadLock(() => solution
                .GetAllProjects()
                .Select(host.GetIdByItem)
                .Select(id => new Rider.Model.ProjectModel(id))
                .AsList());
        }
    }
}
