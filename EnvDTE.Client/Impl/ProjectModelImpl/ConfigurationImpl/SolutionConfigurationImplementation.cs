using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.ConfigurationImpl;

public class SolutionConfigurationImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] RdSolutionConfiguration configuration,
    [NotNull] SolutionConfigurationsImplementation parent)
    : SolutionConfiguration2
{
    public DTE DTE => dte;
    public SolutionConfigurations Collection => parent;
    public string Name => configuration.Name;
    public string PlatformName => configuration.Platform;

    public void Activate() => dte.DteProtocolModel.Solution_set_ActiveConfiguration.Sync(configuration);

    #region NotImplemented

    public SolutionContexts SolutionContexts => throw new NotImplementedException();

    public void Delete() => throw new NotImplementedException();

    #endregion
}
