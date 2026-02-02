using System.Collections.Generic;
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
    public readonly ISignal<IEnumerable<ProjectHostChange>> ProjectsRemoved = new Signal<IEnumerable<ProjectHostChange>>();
    public readonly ISignal<IEnumerable<ProjectHostChange>> ProjectsAdded = new Signal<IEnumerable<ProjectHostChange>>();
    public readonly ISignal<IEnumerable<ProjectHostChange>> ProjectsUpdated = new Signal<IEnumerable<ProjectHostChange>>();

    // Renames are modeled as Remove + Add
    // Even though we could filter them and treat them as updates, we want to keep them separate because they change projects ID in the project model view host
    public override void BeforeUpdateProjects(ProjectStructureChange change)
    {
        if (change.RemovedProjects.Any()) ProjectsRemoved.Fire(change.RemovedProjects);
    }

    public override void AfterUpdateProjects(ProjectStructureChange change)
    {
        if (change.AddedProjects.Any()) ProjectsAdded.Fire(change.AddedProjects);
        if (change.UpdatedProjects.Any()) ProjectsUpdated.Fire(change.UpdatedProjects);
    }
}
