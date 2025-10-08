using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.DataFlow;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Features.SolutionBuilders;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class SolutionCallbackProvider(
        Lifetime componentLifetime,
        ISolution solution,
        ProjectModelViewHost host,
        ISolutionBuilder builder)
        : IEnvDteCallbackProvider
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

            model.Solution_build.SetSync((lifetime, args) =>
            {
                var request = builder.CreateBuildRequest(
                    args.BuildSessionTarget.FromRdBuildSessionTarget(),
                    null,
                    SolutionBuilderRequestSilentMode.Default);

                componentLifetime.OnTermination(() => request.Abort());
                builder.ExecuteBuildRequest(request);

                if (args.WaitForBuild)
                    request.State.WaitForValue(lifetime, state => state.HasFlag(BuildRunState.Completed));

                return Unit.Instance;
            });

            model.Solution_get_BuildState.SetSync(_ =>
                builder.RunningRequest.Value is null
                    ? RdBuildState.NotStarted
                    : builder.RunningRequest.Value.State.Value == BuildRunState.Completed
                        ? RdBuildState.Done
                        : RdBuildState.InProgress);

            // Returns the number of projects that failed to build
            model.Solution_get_LastBuildInfo.SetSync(_ => builder.RunningRequest.Value?.GetAllBuildErrors()
                .Select(e => e.ProjectId).Distinct().Count() ?? 0);
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
