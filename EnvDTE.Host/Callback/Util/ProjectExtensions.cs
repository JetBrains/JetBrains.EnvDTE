using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Application.Components;
using JetBrains.Lifetimes;
using JetBrains.Platform.MsBuildHost.Models;
using JetBrains.Platform.MsBuildHost.ProjectModel;
using JetBrains.Platform.MsBuildHost.Utils;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost;
using JetBrains.ProjectModel.ProjectsHost.MsBuild;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost;
using JetBrains.ProjectModel.Properties;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Threading;
using JetBrains.Util;
using JetBrains.Util.Logging;

namespace JetBrains.EnvDTE.Host.Callback.Util;

public static class ProjectExtensions
{
    private static readonly Key UniqueNameKey = new("EnvDTE.UniqueName");
    private static readonly ILogger Log = Logger.GetLogger<IProject>();

    [PublicAPI]
    [ItemCanBeNull]
    public static async Task<string> GetPropertyAsync(
        [NotNull] this IProject project,
        Lifetime lifetime,
        [NotNull] string name)
    {
        var value = await lifetime.StartReadActionAsync(() =>
            project.GetRequestedProjectProperty(project.GetCurrentTargetFrameworkId(), name));

        if (value is not null) return value;

        Log.Verbose($"Property '{name}' not found in configuration's properties collection. Falling back to MSBuild.");

        var projectHostContainer = project.GetSolution().ProjectsHostContainer();
        var solutionHost = projectHostContainer.GetComponent<ISolutionHost>();
        var projectMark = project.GetProjectMark();
        if (projectMark is null)
        {
            Log.Warn($"Project mark not found for project: {project.Name}.");
            return null;
        }

        if (solutionHost.GetProjectHost(projectMark) is MsBuildProjectHost projectHost)
        {
            value = await lifetime.StartMainRead(() => projectHost.Session.GetProjectProperty(projectMark, name, project.GetCurrentTargetFrameworkId(),
                MsBuildEvaluationMode.Expand));
        }
        else
        {
            Log.Warn($"Project '{project.Name}' is not hosted on {nameof(MsBuildProjectHost)}.");
        }

        return value;
    }

    [PublicAPI]
    public static async Task SetPropertyAsync(
        [NotNull] this IProject project,
        Lifetime lifetime,
        [NotNull] string name,
        [CanBeNull] string value)
    {
        var projectMark = project.GetProjectMark();
        if (projectMark is null)
        {
            Log.Warn($"Project mark not found for project: {project.Name}.");
            return;
        }

        var projectHostContainer = project.GetSolution().ProjectsHostContainer();
        var projectHost = projectHostContainer.GetComponent<MsBuildProjectHost>();
        var solutionHost = projectHostContainer.GetComponent<ISolutionHost>();

        var rdSaveProperties = new List<RdSaveProperty>
        {
            // Even though we use `null` for configuration, the property will be set at the right place
            MsBuildModelHelper.CreateSimpleSaveProperty(name, value, null)
        };
        await lifetime.StartMainWrite(() => projectHost.SaveProperties(projectMark, rdSaveProperties));

        project.GetSolution().GetSolutionLifetimes().UntilSolutionCloseLifetime.StartMainWrite(() =>
            solutionHost.ReloadProjectAsync(projectMark)).NoAwait();
    }

    /// <summary>
    /// Asynchronously retrieves the unique Visual Studio name for the specified project.
    /// </summary>
    [PublicAPI]
    public static async Task<string> GetVSUniqueNameAsync([NotNull] this IProject project, Lifetime lifetime)
    {
        if (project.IsSolutionProject())
        {
            Log.Warn("Visual Studio does not have the project for the solution, returning empty string.");
            return string.Empty;
        }

        var uniqueName = await lifetime.StartReadActionAsync(() => project.GetProperty(UniqueNameKey) as string);
        if (uniqueName is not null) return uniqueName;

        uniqueName = CalculateProjectUniqueName(project);
        // Save the unique name to the project properties so we don't have to calculate it every time
        await lifetime.StartMainWrite(() => project.SetProperty(UniqueNameKey, uniqueName));
        return uniqueName;
    }

    // Per documentation, VS uses CPS only for SDK-style .NET projects and Shared projects
    [PublicAPI]
    public static bool IsCPSProject([NotNull] this IProject project) => project.IsDotNetCoreProject() || project.IsSharedProject();

    /// <summary>
    /// Returns the hierarchical path of the project as a list of project model item IDs.
    /// This path is meant to be used with <c>ProjectImplementation.GetFromPath</c> on the client side to retrieve the project.
    /// </summary>
    [PublicAPI]
    public static List<int> GetProjectPath([NotNull] this IProject project, ProjectModelViewHost viewHost) =>
        project.GetPathChain().Select(viewHost.GetIdByItem).Reverse().ToList();

    private static string CalculateProjectUniqueName([NotNull] IProject project)
    {
        if (project.IsMiscFilesProject()) return "<MiscFiles>";
        if (project.IsSolutionFolder()) return $"{project.Name}{project.Guid.ToString("B").ToUpperInvariant()}";

        var solutionDirPath = project.GetSolution().SolutionDirectory;
        var projectFilePath = project.ProjectFileLocation;

        return projectFilePath.MakeRelativeTo(solutionDirPath).FullPath;
    }
}
