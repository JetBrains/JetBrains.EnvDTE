using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class SolutionCallbackProvider(ISolution solution, ProjectModelViewHost host) : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(DteProtocolModel model)
        {
            model.Solution_FileName.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => solution.SolutionFilePath.FullPath));
            model.Solution_Count.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => GetFilteredProjects().Count()));
            model.Solution_Item.SetAsync(async (lifetime, index) =>
            {
                var projects = await lifetime.StartReadActionAsync(() => GetFilteredProjects().ToArray());
                return index >= projects.Length ? null : projects.ElementAt(index);
            });
            model.Solution_get_Projects.SetAsync((lifetime, _) =>
                lifetime.StartReadActionAsync(() => GetFilteredProjects().AsList()));
        }

        // Misc project is also displayed in VS and our approach of using item id does not allow that because it doesn't
        // have a unique id. In the future it would be better to start using project guids instead, but since that complicates
        // the client side, I'm not going to do it now.
        private IEnumerable<ProjectItemModel> GetFilteredProjects() => solution.GetAllProjects()
            .Where(p => p.ParentFolder is null)
            .Select(host.GetIdByItem)
            .Where(id => id != 0)
            .Select(id => new ProjectItemModel(id));
    }
}
