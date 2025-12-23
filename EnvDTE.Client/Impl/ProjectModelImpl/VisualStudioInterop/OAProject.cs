using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl;
using JetBrains.Rider.Model;
using Microsoft.VisualStudio.ProjectSystem.Properties;

namespace Microsoft.VisualStudio.ProjectSystem.VS.Implementation.Package.Automation;

public class OAProject(
    [NotNull] DteImplementation dte,
    [NotNull] ProjectItemModel projectModel,
    [CanBeNull] ProjectItemImplementation parentProjectItem = null)
    : ProjectImplementation(dte, projectModel, parentProjectItem), IVsBrowseObjectContext
{
    public UnconfiguredProject UnconfiguredProject { get; } = new UnconfiguredProjectImpl(dte, projectModel);
}
