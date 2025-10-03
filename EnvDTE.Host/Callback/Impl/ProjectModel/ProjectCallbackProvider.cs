using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.EnvDTE.Host.Callback.Impl.Properties;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using Key = JetBrains.Util.Key;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModel
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class ProjectCallbackProvider(ProjectPropertyService propertyService, ISolution solution, ProjectModelViewHost host)
        : IEnvDteCallbackProvider
    {
        private const string SolutionFolderProjectGuid = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
        private readonly Key _uniqueNameKey = new("EnvDTE.UniqueName");

        public void RegisterCallbacks(DteProtocolModel model)
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

            model.Project_get_UniqueName.SetAsync(async (lifetime, projectModel) =>
            {
                var project = GetProject(projectModel);
                if (project is null) return string.Empty;

                string uniqueName = null;
                await lifetime.StartReadActionAsync(() =>
                {
                    uniqueName = project.GetProperty(_uniqueNameKey) as string;
                });
                if (uniqueName is not null) return uniqueName;

                uniqueName = CalculateProjectUniqueName(project);
                // Save the unique name to the project properties so we don't have to calculate it every time
                await lifetime.StartMainWrite(() => project.SetProperty(_uniqueNameKey, uniqueName));
                return uniqueName;
            });

            model.Project_get_Kind.SetSync(projectModel =>
            {
                var project = GetProject(projectModel);
                if (project is null) return string.Empty;

                if (project.ProjectProperties.ProjectKind == ProjectKind.SOLUTION_FOLDER) return SolutionFolderProjectGuid;

                var guid = project.ProjectProperties.ProjectTypeGuids.FirstOrDefault();
                return guid.ToString("B").ToUpperInvariant();
            });

            model.Project_get_Property.SetAsync((lifetime, args) =>
            {
                var project = GetProject(args.Model);
                if (project is null) return Task.FromResult<string>(null);

                return propertyService.GetPropertyAsync(lifetime, project, args.Name);
            });

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
        }

        [CanBeNull]
        private IProject GetProject(Rider.Model.ProjectModel rdModel) => host.GetItemById<IProject>(rdModel.Id);

        private static string CalculateProjectUniqueName([NotNull] IProject project)
        {
            var solutionDirPath = project.GetSolution().SolutionDirectory;
            var projectFilePath = project.ProjectFileLocation;

            return projectFilePath.MakeRelativeTo(solutionDirPath).FullPath;
        }
    }
}
