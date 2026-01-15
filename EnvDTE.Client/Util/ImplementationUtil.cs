using System;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl;
using JetBrains.Rider.Model;
using Microsoft.VisualStudio.ProjectSystem.VS.Implementation.Package.Automation;

namespace JetBrains.EnvDTE.Client.Util;

internal static class ImplementationUtil
{
    internal static int GetValidIndexOrThrow(object index, int? count = null)
    {
        if (index is not int number) throw new ArgumentException();
        // Indexes are 1-based in EnvDTE
        if (number < 1 || number > count) throw new ArgumentOutOfRangeException();
        return number - 1;
    }

    internal static ProjectImplementation GetProjectImplementation(DteImplementation dte,
        ProjectItemModel projectItemModel, bool isCPS, [CanBeNull] ProjectItemImplementation parent = null) => isCPS
            ? new OAProject(dte, projectItemModel, parent)
            : new ProjectImplementation(dte, projectItemModel, parent);

    internal static ProjectImplementation GetProjectImplementation(DteImplementation dte,
        ProjectItemModel projectItemModel, [CanBeNull] ProjectItemImplementation parent = null)
    {
        var isCPS = dte.DteProtocolModel.Project_is_CPS.Sync(new ProjectItemRequest(projectItemModel));
        return GetProjectImplementation(dte, projectItemModel, isCPS, parent);
    }
}
