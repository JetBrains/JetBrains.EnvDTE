using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent(InstantiationEx.LegacyDefault)]
    public sealed class ProjectCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            AstManager astManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            model.Project_get_Name.SetWithReadLock(projectModel => host.GetItemById<IProject>(projectModel.Id)?.Name ?? "");
            model.Project_set_Name.SetWithReadLock(request =>
            {
                string name = request.NewName;
                var project = host.GetItemById<IProject>(request.Model.Id);
                if (project == null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Rename(project, name));
                return Unit.Instance;
            });
            model.Project_get_FileName.SetWithReadLock(projectModel =>
                host.GetItemById<IProject>(projectModel.Id)?.ProjectFile?.Name ?? "");
            model.Project_Delete.SetWithReadLock(projectModel =>
            {
                var project = host.GetItemById<IProject>(projectModel.Id);
                if (project == null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Remove(project));
                return Unit.Instance;
            });
        }
    }
}
