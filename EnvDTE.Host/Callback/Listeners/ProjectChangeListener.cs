using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.Collections.Viewable;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost.Impl;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Listeners;

[SolutionInstanceComponent(Instantiation.DemandAnyThreadSafe)]
public class ProjectChangeListener : SolutionHostSyncListener
{
    public readonly ISignal<ProjectHostChange[]> ProjectsRemoved = new Signal<ProjectHostChange[]>();
    public readonly ISignal<ProjectHostChange[]> ProjectsAdded = new Signal<ProjectHostChange[]>();
    public readonly ISignal<ProjectHostChange[]> ProjectsUpdated = new Signal<ProjectHostChange[]>();

    public override void BeforeUpdateProjects(ProjectStructureChange change)
    {
        // Renames are modeled as Remove + Add; We want to ignore them
        var addedProjectsSet = change.AddedProjects.ToHashSet(c => c.ProjectMark.Guid);
        var removedProjectsSet = change.RemovedProjects.Where(c => !addedProjectsSet.Contains(c.ProjectMark.Guid));

        ProjectsRemoved.Fire(removedProjectsSet.ToArray());
    }

    public override void AfterUpdateProjects(ProjectStructureChange change)
    {
        // Renames are modeled as Remove + Add; We want to ignore them
        var removedProjectSet = change.RemovedProjects.ToHashSet(c => c.ProjectMark.Guid);
        var addedProjects = change.AddedProjects.Where(c => !removedProjectSet.Contains(c.ProjectMark.Guid));

        ProjectsAdded.Fire(addedProjects.ToArray());
        ProjectsUpdated.Fire(change.UpdatedProjects.ToArray());
    }
}
