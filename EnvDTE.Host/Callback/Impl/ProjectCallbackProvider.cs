using JetBrains.Core;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    public sealed class ProjectCallbackProvider : ICallbackProvider
    {
        public void RegisterCallbacks(ISolution solution, ProjectModelViewHost host, DteProtocolModel model)
        {
            model.Project_get_Name.Set(projectModel => host.GetItemById<IProject>(projectModel.Id)?.Name ?? "");
            model.Project_set_Name.Set(request =>
            {
                string name = request.NewName;
                var project = host.GetItemById<IProject>(request.Model.Id);
                if (project == null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Rename(project, name));
                return Unit.Instance;
            });
            model.Project_get_FileName.Set(projectModel =>
                host.GetItemById<IProject>(projectModel.Id)?.ProjectFile?.Name ?? "");
            model.Project_Delete.Set(projectModel =>
            {
                var project = host.GetItemById<IProject>(projectModel.Id);
                if (project == null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Remove(project));
                return Unit.Instance;
            });
        }
    }
}
