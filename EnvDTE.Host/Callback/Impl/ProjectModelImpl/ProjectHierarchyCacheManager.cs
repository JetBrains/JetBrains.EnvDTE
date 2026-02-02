using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Application.Threading;
using JetBrains.Collections.Viewable;
using JetBrains.EnvDTE.Host.Callback.Listeners;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost;
using JetBrains.ProjectModel.ProjectsHost.Impl;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl;

[SolutionComponent(Instantiation.DemandAnyThreadSafe)]
public class ProjectHierarchyCacheManager(
    ILogger logger,
    Lifetime componentLifetime,
    ISolution solution,
    ProjectModelViewHost modelViewHost,
    ProjectChangeListener projectChangeListener,
    VsProjectCompatibilityService vsCompatibilityService)
    : IEnvDteCallbackProvider
{
    [CanBeNull] private DteProtocolModel _model;
    [CanBeNull] private IScheduler _scheduler;

    public void RegisterCallbacks(DteProtocolModel model, IScheduler scheduler)
    {
        _model = model;
        _scheduler = scheduler;

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

        projectChangeListener.ProjectsRemoved.Advise(componentLifetime, OnProjectsRemoved);
        projectChangeListener.ProjectsAdded.Advise(componentLifetime, OnProjectsAdded);
        projectChangeListener.ProjectsUpdated.Advise(componentLifetime, OnProjectsUpdated);
    }

    private void OnProjectsRemoved(IEnumerable<ProjectHostChange> changes)
    {
        if (_model is null || _scheduler is null) return;

        foreach (var projectChange in changes)
        {
            var args = GetArgsForRemoval(projectChange);
            if (args is null) continue;

            _scheduler.Queue(() => _model.ProjectHierarchyCache_remove_Project(args));
        }
    }

    private void OnProjectsAdded(IEnumerable<ProjectHostChange> changes)
    {
        if (_model is null || _scheduler is null) return;

        // Flatten the hierarchy - parents should be processed before children
        var addedInOrder = FlattenHierarchy(changes.Where(c => c.Parent is null));

        foreach (var projectChange in addedInOrder)
        {
            var args = GetArgsForAddition(projectChange);
            if (args is null) continue;

            _scheduler.Queue(() => _model.ProjectHierarchyCache_add_Project(args));
        }
    }

    private void OnProjectsUpdated(IEnumerable<ProjectHostChange> changes)
    {
        if (_model is null || _scheduler is null) return;

        foreach (var projectChange in changes)
        {
            var args = GetArgsForAddition(projectChange);
            if (args is null) continue;

            _scheduler.Queue(() => _model.ProjectHierarchyCache_update_Project(args));
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
            vsCompatibilityService.IsCPSProject(project),
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
            vsCompatibilityService.IsCPSProject(project),
            change.ProjectMark.Parent is null ? null : GetProjectItemModel(change.ProjectMark.Parent));
    }

    private ProjectHierarchyCacheEventArgs GetArgs(IProject project) => new(
        GetProjectItemModel(project),
        vsCompatibilityService.IsCPSProject(project),
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
