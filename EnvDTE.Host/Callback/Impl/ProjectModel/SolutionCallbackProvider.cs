using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class SolutionCallbackProvider(ISolution solution, ProjectModelViewHost host) : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(DteProtocolModel model)
        {
            model.Solution_FileName.SetWithReadLock(solution.Locks, () => solution.SolutionFilePath.FullPath);
            model.Solution_Count.SetWithReadLock(solution.Locks, () => solution.GetAllProjects().Count);
            model.Solution_Item.SetWithReadLock(solution.Locks, index =>
            {
                var projects = solution.GetAllProjects();
                if (projects.Count < index) return new Rider.Model.ProjectModel(-1);
                var project = projects.ElementAt(index - 1);
                int id = host.GetIdByItem(project);
                return new Rider.Model.ProjectModel(id);
            });
            model.Solution_get_Projects.SetWithReadLock(solution.Locks, () => solution
                .GetAllProjects()
                .Select(host.GetIdByItem)
                .Where(id => id != 0)
                .Select(id => new Rider.Model.ProjectModel(id))
                .AsList());
        }
    }
}
