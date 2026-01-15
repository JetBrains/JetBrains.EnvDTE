using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Application.Threading;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost;
using JetBrains.ProjectModel.ProjectsHost.Impl;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl;

[SolutionInstanceComponent(Instantiation.DemandAnyThreadSafe)]
public class SolutionSyncListener(
    Lifetime componentLifetime,
    ILogger logger,
    ISolution solution,
    ProjectModelViewHost modelViewHost)
    : SolutionHostSyncListener, IEnvDteCallbackProvider
{
    [CanBeNull] private DteProtocolModel _model;

    public void RegisterCallbacks(DteProtocolModel model)
    {
        _model = model;

        /*
         * Project loading is delivered as a single “bulk add” update: once the IDE has finished loading, an update event
         * is fired whose AddedProjects contains *all* solution projects.
         *
         * Before that event, the solution effectively has no real projects yet (apart from misc/solution), so 'GetTopLevelProjects()'/'GetAllProjects()'
         * will return an empty list (the list will actually contain misc and solution projects, but those are not relevant).
         *
         * There is no intermediate state where only a subset of loaded projects is visible. As a result, cache initialization is robust:
         *  - If requestInitialization is called early, it returns an empty list and subsequent events populate the cache.
         *  - If it is called after loading, it returns the complete project list.
         */
        // TODO: Ordering projects in this call is probably not needed, because of the way cache is populated on the client side and the way project loading is performed
        _model.ProjectHierarchyCache_requestInitialization.SetAsync((lifetime, _) =>
            solution.Locks.ExecuteOrQueueReadLockAsync(lifetime, "EnvDTE.ProjectHierarchyCache.requestInitialization",
                () =>
                {
                    // GetAllProjects doesn't guarantee hierarchical ordering
                    var visitor = new ProjectHierarchyVisitor();
                    foreach (var topLevel in solution.GetTopLevelProjects())
                    {
                        topLevel.Accept(visitor);
                    }

                    return visitor.Projects.Select(GetArgs).ToList();
                }));
    }

    public override void BeforeUpdateProjects(ProjectStructureChange change)
    {
        if (_model is null) return;

        // Renames are modeled as Remove + Add; We want to ignore them
        var addedProjectsSet = change.AddedProjects.ToHashSet(c => c.ProjectMark.Guid);

        foreach (var projectChange in change.RemovedProjects)
        {
            if (addedProjectsSet.Contains(projectChange.ProjectMark.Guid)) continue;

            var args = GetArgsForRemoval(projectChange);
            if (args is null) continue;

            _model.ProjectHierarchyCache_remove_Project(args);
        }
    }

    public override void AfterUpdateProjects(ProjectStructureChange change)
    {
        if (_model is null) return;

        // Renames are modeled as Remove + Add; We want to ignore them
        var removedProjectSet = change.RemovedProjects.ToHashSet(c => c.ProjectMark.Guid);

        // Flatten the hierarchy - parents should be processed before children
        var addedInOrder = FlattenHierarchy(change.AddedProjects.Where(c => c.Parent == null));

        foreach (var projectChange in addedInOrder)
        {
            if (removedProjectSet.Contains(projectChange.ProjectMark.Guid)) continue;

            var args = GetArgsForAddition(projectChange);
            if (args is null) continue;

            _model.ProjectHierarchyCache_add_Project(args);
        }

        foreach (var projectChange in change.UpdatedProjects)
        {
            var args = GetArgsForAddition(projectChange);
            if (args is null) continue;

            _model.ProjectHierarchyCache_update_Project(args);
        }
    }

    private static IEnumerable<ProjectHostChange> FlattenHierarchy(IEnumerable<ProjectHostChange> roots)
    {
        foreach (var root in roots)
        {
            yield return root;
            foreach (var child in FlattenHierarchy(root.Children))
            {
                yield return child;
            }
        }
    }

    /*
     * The separate methods exist because of the way 'ProjectModelViewHost' updates item IDs when a project is added or removed.
     *
     * Add:
     *   The 'IProjectMark' is registered in the view host before the 'IProject' is registered.
     *   During the callback, querying the host by 'IProject' can return ID = 0 (not registered yet).
     *   Therefore, 'GetArgsForAddition' resolves the ID via 'IProjectMark'.
     *
     * Remove:
     *   The 'IProjectMark' is unregistered in the view host before the 'IProject' is unregistered.
     *   During the callback, querying the host by 'IProjectMark' can return ID = 0 (already unregistered).
     *   Therefore, 'GetArgsForRemoval' resolves the ID via the 'IProject' instance.
     *
     * Update:
     *   Both 'IProject' and 'IProjectMark' can be used for ID retrieval.
     */

    [CanBeNull]
    private ProjectHierarchyCacheEventArgs GetArgsForRemoval(ProjectHostChange change)
    {
        var project = solution.GetProjectByMark(change.ProjectMark);
        if (project is null)
        {
            logger.Error($"REMOVE: Project not found for mark: {change.ProjectMark.Guid}");
            return null;
        }

        return new ProjectHierarchyCacheEventArgs(
            GetProjectItemModel(project),
            project.IsCPSProject(componentLifetime),
            project.ParentFolder is null ? null : GetProjectItemModel(project.ParentFolder));
    }

    [CanBeNull]
    private ProjectHierarchyCacheEventArgs GetArgsForAddition(ProjectHostChange change)
    {
        var project = solution.GetProjectByMark(change.ProjectMark);
        if (project is null)
        {
            logger.Error($"ADD: Project not found for mark: {change.ProjectMark.Guid}");
            return null;
        }

        return new ProjectHierarchyCacheEventArgs(
            GetProjectItemModel(change.ProjectMark),
            project.IsCPSProject(componentLifetime),
            change.ProjectMark.Parent is null ? null : GetProjectItemModel(change.ProjectMark.Parent));
    }

    private ProjectHierarchyCacheEventArgs GetArgs(IProject project) => new(
        GetProjectItemModel(project),
        project.IsCPSProject(componentLifetime),
        project.ParentFolder is null ? null : GetProjectItemModel(project.ParentFolder));

    private ProjectItemModel GetProjectItemModel<T>(T item) => new(modelViewHost.GetIdByItem(item));

    private class ProjectHierarchyVisitor : RecursiveProjectVisitor
    {
        private readonly List<IProject> _projects = [];

        public IReadOnlyList<IProject> Projects => _projects;

        public override void VisitProject(IProject project)
        {
            if (!project.IsMiscFilesProject() && !project.IsSolutionProject())
            {
                _projects.Add(project);
            }

            base.VisitProject(project);
        }
    }
}
