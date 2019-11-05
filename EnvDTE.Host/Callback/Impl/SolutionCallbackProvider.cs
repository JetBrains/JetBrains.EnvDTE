using System.Linq;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    public sealed class SolutionCallbackProvider : ICallbackProvider
    {
        public void RegisterCallbacks(ISolution solution, ProjectModelViewHost host, DteProtocolModel model)
        {
            model.Solution_FileName.Set(_ => solution.SolutionFilePath.FullPath);
            model.Solution_Count.Set(_ => solution.GetAllProjects().Count);
            model.Solution_Item.Set(index =>
            {
                var projects = solution.GetAllProjects();
                if (projects.Count >= index) return new Rider.Model.ProjectModel(-1);
                var project = projects.ElementAt(index + 1);
                int id = host.GetIdByItem(project);
                return new Rider.Model.ProjectModel(id);
            });
            model.Solution_get_Projects.Set(_ => solution
                .GetAllProjects()
                .Select(host.GetIdByItem)
                .Select(id => new Rider.Model.ProjectModel(id))
                .AsList());
        }
    }
}
