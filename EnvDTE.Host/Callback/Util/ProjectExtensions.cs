using System;
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
using JetBrains.ProjectModel.Properties.Flavours;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Threading;
using JetBrains.Util;
using JetBrains.Util.Logging;

namespace JetBrains.EnvDTE.Host.Callback.Util;

public static class ProjectExtensions
{
    private const string FSharpProjectTypeGuid = "f2a71f9b-5d33-465a-a702-920d77279786";

    private static readonly Key UniqueNamePropertyKey = new("EnvDTE.UniqueName");
    private static readonly Key IsCPSPropertyKey = new("EnvDTE.IsCPS");
    private static readonly ILogger Log = Logger.GetLogger<IProject>();

    /// <summary>
    /// Asynchronously retrieves the specified project property.
    /// </summary>
    /// <remarks>
    /// First tries to retrieve the property value from the configuration's properties collection. If the property is not
    /// found, it falls back to reading the property value from the underlying MSBuild project model.
    /// </remarks>
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
            value = await lifetime.StartMainRead(() => projectHost.Session.GetProjectProperty(projectMark, name,
                project.GetCurrentTargetFrameworkId(),
                MsBuildEvaluationMode.Expand));
        }
        else
        {
            Log.Warn($"Project '{project.Name}' is not hosted on {nameof(MsBuildProjectHost)}.");
        }

        return value;
    }

    /// <summary>
    /// Asynchronously sets the specified project property.
    /// </summary>
    /// <remarks>
    /// Writes the property value directly to the underlying MSBuild project model and triggers the project reload so the
    /// updated value becomes visible in the project as soon as possible.
    /// </remarks>
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

        // Save the unique name to the project properties so we don't have to calculate it every time
        return await project.GetOrCreatePropertyAsync(lifetime, UniqueNamePropertyKey, CalculateProjectUniqueName);
    }

    /// <summary>
    /// Determines whether the project is a CPS (Common Project System) project in Visual Studio.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The official documentation for the Visual Studio’s CPS-based project system states that it is primarily used for
    /// SDK-style .NET projects and .NET shared projects. In practice, there are additional project types that are implemented
    /// on top of CPS and have the 'CPS' capability.
    /// </para>
    /// <para>
    /// CPS is also used for FSharp, EcmaScript (JS, TS, ...), SDK-style SQL, Docker Compose, Service Fabric and
    /// Windows Application Packaging projects.
    /// CPS is not used for classic .NET, classic SQL, Python and C++ projects, as well as some niche project types like Hive,
    /// Pig, Azure Stream Analytics, Azure Cloud Service and U-SQL projects.
    /// </para>
    /// <para>
    /// Neither of the above lists is complete, but they cover the major, commonly encountered, project types.
    /// Existing checks also have a high chance of covering other project types that are not explicitly listed here.
    /// </para>
    /// </remarks>
    [PublicAPI]
    public static Task<bool> IsCPSProjectAsync([NotNull] this IProject project, Lifetime lifetime) =>
        project.GetOrCreatePropertyAsync(lifetime, IsCPSPropertyKey, p =>
            p.IsProjectFromUserView() && !p.IsSolutionFolder() &&
            (p.IsDotNetCoreProject() || (p.IsSharedProject() && !IsCppProject(p)) || p.IsDockerComposeProject()
             || p.IsEcmaScriptProject() || IsFSharpProject(p) || IsServiceFabricProject(p)));

    [PublicAPI]
    private static bool IsFSharpProject([NotNull] this IProject project) =>
        project.ProjectProperties.ProjectTypeGuids.LastOrDefault().ToString().Equals(FSharpProjectTypeGuid);

    [PublicAPI]
    public static bool IsCppProject([NotNull] this IProject project) => project.HasFlavour<CppProjectFlavor>();

    [PublicAPI]
    public static bool IsServiceFabricProject([NotNull] this IProject project) =>
        project.HasFlavour<ServiceFabricProjectFlavor>();

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

    private static async Task<T> GetOrCreatePropertyAsync<T>([NotNull] this IProject project, Lifetime lifetime,
        Key key, Func<IProject, T> calculateValue)
    {
        var value = await lifetime.StartReadActionAsync(() => project.GetProperty(key));
        if (value is not null) return value.GetType() == typeof(T) ? (T)value : default;

        var newValue = calculateValue(project);
        await lifetime.StartMainWrite(() => project.SetProperty(key, newValue));
        return newValue;
    }
}
