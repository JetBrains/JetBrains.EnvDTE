using System.Collections.Generic;
using JetBrains.Core;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rd.Tasks;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl;

public class ProjectHierarchyCache
{
    private readonly Dictionary<ProjectItemModel, ProjectImplementation> _projectCache = new();
    private readonly DteImplementation _dte;
    private readonly object _lock = new();

    public ProjectHierarchyCache(DteImplementation dte)
    {
        _dte = dte;

        dte.DteProtocolModel.ProjectHierarchyCache_add_Project.Advise(dte.DteLifetime, OnProjectAdded);
        dte.DteProtocolModel.ProjectHierarchyCache_remove_Project.Advise(dte.DteLifetime, OnProjectRemoved);
        dte.DteProtocolModel.ProjectHierarchyCache_update_Project.Advise(dte.DteLifetime, OnProjectUpdated);

        lock (_lock)
        {
            // Could take a bit longer then max Rpc timeout, so we use Start
            var initialProjects = dte.DteProtocolModel.ProjectHierarchyCache_requestInitialization
                .Start(dte.DteLifetime, Unit.Instance)
                .GetAwaiter().GetResult();
            PopulateCache(initialProjects);
        }
    }

    public ProjectImplementation GetProject(ProjectItemModel projectItemModel)
    {
        lock (_lock)
        {
            return _projectCache[projectItemModel];
        }
    }

    private void PopulateCache(List<ProjectHierarchyCacheEventArgs> args)
    {
        foreach (var arg in args)
        {
            _projectCache[arg.Project] = ImplementationUtil.GetProjectImplementation(_dte, arg.Project, arg.IsCPS);
        }

        foreach (var arg in args)
        {
            if (arg.ParentProject is null) continue;

            _projectCache[arg.Project].parentProjectItemImplementation = new SolutionFolderProjectItemImplementation(_dte, arg.Project, _projectCache[arg.ParentProject]);
        }
    }

    private void OnProjectAdded(ProjectHierarchyCacheEventArgs args)
    {
        lock (_lock)
        {
            _projectCache[args.Project] = ImplementationUtil.GetProjectImplementation(_dte, args.Project, args.IsCPS);

            if (args.ParentProject is not null)
                _projectCache[args.Project].parentProjectItemImplementation =
                    new SolutionFolderProjectItemImplementation(_dte, args.Project, _projectCache[args.ParentProject]);
        }
    }

    private void OnProjectRemoved(ProjectHierarchyCacheEventArgs args)
    {
        lock (_lock)
        {
            _projectCache.Remove(args.Project);
        }
    }

    private void OnProjectUpdated(ProjectHierarchyCacheEventArgs args)
    {
        lock (_lock)
        {
            var project = _projectCache[args.Project];
            if (project.parentProjectItemImplementation?.ProjectItemModel.Equals(args.ParentProject) ?? args.ParentProject is null)
                return;

            ProjectItemImplementation newParentItem = null;
            if (args.ParentProject is not null)
                newParentItem = new SolutionFolderProjectItemImplementation(_dte, args.Project, _projectCache[args.ParentProject]);

            project.parentProjectItemImplementation = newParentItem;
        }
    }
}
