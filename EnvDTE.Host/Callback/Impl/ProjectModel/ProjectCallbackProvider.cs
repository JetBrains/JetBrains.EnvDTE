using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.EnvDTE.Host.Callback.Impl.Properties;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel
{
    [SolutionComponent(InstantiationEx.LegacyDefault)]
    public sealed class ProjectCallbackProvider(ProjectPropertyService propertyService) : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            AstManager astManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            model.Project_get_Name.SetWithReadLock(solution.Locks,
                projectModel => GetProject(projectModel)?.Name ?? string.Empty);

            model.Project_set_Name.SetWithReadLock(solution.Locks, request =>
            {
                var name = request.NewName;
                var project = GetProject(request.Model);
                if (project is null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Rename(project, name));
                return Unit.Instance;
            });

            model.Project_get_FileName.SetWithReadLock(solution.Locks, projectModel =>
                GetProject(projectModel)?.ProjectFileLocation.FullPath ?? string.Empty);

            model.Project_get_Kind.SetSync(projectModel =>
            {
                var guid = GetProject(projectModel)?.ProjectProperties.ProjectTypeGuids.FirstOrDefault();
                return guid is null ? string.Empty : guid.Value.ToString("B").ToUpperInvariant();
            });

            model.Project_get_Property.SetAsync((lifetime, args) =>
            {
                var project = GetProject(args.Model);
                if (project is null) return null;

                return propertyService.GetPropertyAsync(lifetime, project, args.Name);
            });

            model.Project_getType_Property.SetSync(args =>
                propertyService.GetPropertyType(args.Name));

            model.Project_set_Property.SetVoidAsync(async (lifetime, args) =>
            {
                var project = GetProject(args.Model);
                if (project is null) return;

                await propertyService.SetPropertyAsync(lifetime, project, args.Name, args.Value);
            });

            model.Project_Delete.SetWithReadLock(solution.Locks, projectModel =>
            {
                var project = GetProject(projectModel);
                if (project is null) return Unit.Instance;
                solution.InvokeUnderTransaction(cookie => cookie.Remove(project));
                return Unit.Instance;
            });
            return;

            [CanBeNull]
            IProject GetProject(Rider.Model.ProjectModel rdModel) => host.GetItemById<IProject>(rdModel.Id);
        }
    }
}
