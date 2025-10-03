using System;
using System.Collections.Generic;
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
                var projects = GetFilteredProjects().ToArray();
                if (index >= projects.Length) return null;
                return projects.ElementAt(index);
            });
            model.Solution_get_Projects.SetWithReadLock(solution.Locks, () => GetFilteredProjects().AsList());
        }

        // Misc project is also displayed in VS and our approach of using item id does not allow that because it doesn't
        // have a unique id. In the future it would be better to start using project guids instead, but since that complicates
        // the client side, I'm not going to do it now.
        private IEnumerable<Rider.Model.ProjectModel> GetFilteredProjects() => solution.GetAllProjects()
            .Where(p => p.ParentFolder is null)
            .Select(host.GetIdByItem)
            .Where(id => id != 0)
            .Select(id => new Rider.Model.ProjectModel(id));
    }
}
