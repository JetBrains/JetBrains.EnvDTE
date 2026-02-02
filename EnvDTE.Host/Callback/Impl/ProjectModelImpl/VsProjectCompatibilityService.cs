using System;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Threading;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl;

/// <summary>
/// Provides Visual Studio-compatible project information, caching results as project properties when possible.
/// </summary>
[SolutionComponent(Instantiation.DemandAnyThreadSafe)]
public class VsProjectCompatibilityService(ILogger logger, Lifetime lifetime)
{
    private static readonly Key UniqueNamePropertyKey = new("EnvDTE.UniqueName");
    private static readonly Key IsCPSPropertyKey = new("EnvDTE.IsCPS");

    /// <summary>
    /// Retrieves the unique Visual Studio name for the specified project.
    /// </summary>
    [PublicAPI]
    public string GetVSUniqueName([NotNull] IProject project)
    {
        if (project.IsSolutionProject())
        {
            logger.Warn("Visual Studio does not have the project for the solution, returning empty string.");
            return string.Empty;
        }

        if (project.IsWebProject())
        {
            // Website projects do not have a project file, so their unique name is the path to the project directory
            return project.Location.FullPath;
        }

        // Save the unique name to the project properties so we don't have to calculate it every time
        return GetOrCreateProperty(project, UniqueNamePropertyKey, CalculateProjectUniqueName);
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
    public bool IsCPSProject([NotNull] IProject project) =>
        GetOrCreateProperty(project, IsCPSPropertyKey, p =>
            p.IsProjectFromUserView() && !p.IsSolutionFolder() &&
            (p.IsDotNetCoreProject() || (p.IsSharedProject() && !p.IsCppProject()) || p.IsDockerComposeProject()
             || p.IsEcmaScriptProject() || p.IsFSharpProject() || p.IsServiceFabricProject()));

    private static string CalculateProjectUniqueName([NotNull] IProject project)
    {
        if (project.IsMiscFilesProject()) return "<MiscFiles>";
        if (project.IsSolutionFolder()) return $"{project.Name}{project.Guid.ToString("B").ToUpperInvariant()}";

        var solutionDirPath = project.GetSolution().SolutionDirectory;
        var projectFilePath = project.ProjectFileLocation;

        return projectFilePath.MakeRelativeTo(solutionDirPath).FullPath;
    }

    // Currently, there is no need to invalidate values for any of the existing properties.
    // For any of them to change, the project needs to be recreated (this happens even on renames), at which point it won't have any of the properties set.
    private T GetOrCreateProperty<T>([NotNull] IProject project, Key key, Func<IProject, T> calculateValue)
    {
        using (ReadLockCookie.Create())
        {
            var curr = project.GetProperty(key);
            if (curr is T currValue) return currValue;
        }

        var value = calculateValue(project);
        lifetime.StartMainWrite(() =>
        {
            // Double-check, another thread might have set the property while we were calculating
            if (project.GetProperty(key) is T) return;

            project.SetProperty(key, value);
        }).NoAwait();

        return value;
    }
}
