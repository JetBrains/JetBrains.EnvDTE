using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.ConfigurationImpl;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rd.Tasks;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl;

public class SolutionBuildImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] SolutionImplementation parentSolution)
    : SolutionBuild2
{
    [CanBeNull] private SolutionConfigurationsImplementation _solutionConfigurations;

    private SolutionConfigurationsImplementation SolutionConfigurationsImplementation
    {
        get
        {
            _solutionConfigurations ??= new SolutionConfigurationsImplementation(dte, this);
            return _solutionConfigurations;
        }
    }

    public DTE DTE => dte;
    public Solution Parent => parentSolution;

    public vsBuildState BuildState =>
        dte.DteProtocolModel.Solution_get_BuildState.Sync(Unit.Instance).FromRdBuildState();

    public int LastBuildInfo => dte.DteProtocolModel.Solution_get_LastBuildInfo.Sync(Unit.Instance);

    public SolutionConfiguration ActiveConfiguration
    {
        get
        {
            var config = dte.DteProtocolModel.Solution_get_ActiveConfiguration.Sync(Unit.Instance);
            return config is null ? null : new SolutionConfigurationImplementation(dte, config, SolutionConfigurationsImplementation);
        }
    }

    public SolutionConfigurations SolutionConfigurations => SolutionConfigurationsImplementation;

    public void Build(bool waitForBuildToFinish) => BuildInternal(waitForBuildToFinish, RdBuildSessionTarget.Build);
    public void Clean(bool waitForCleanToFinish) => BuildInternal(waitForCleanToFinish, RdBuildSessionTarget.Clean);

    private void BuildInternal(bool waitForBuildToFinish, RdBuildSessionTarget target) => dte.DteProtocolModel.Solution_build
        .Start(dte.DteLifetime, new(waitForBuildToFinish, target))
        .GetAwaiter()
        .GetResult();

    #region NotImplemented

    public BuildDependencies BuildDependencies => throw new NotImplementedException();

    public object StartupProjects
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public int LastPublishInfo => throw new NotImplementedException();
    public vsPublishState PublishState => throw new NotImplementedException();

    public void Debug() => throw new NotImplementedException();
    public void Deploy(bool waitForDeployToFinish) => throw new NotImplementedException();
    public void Run() => throw new NotImplementedException();

    public void BuildProject(string solutionConfiguration, string projectUniqueName, bool waitForBuildToFinish) =>
        throw new NotImplementedException();

    public void Publish(bool waitForPublishToFinish = false) => throw new NotImplementedException();

    public void PublishProject(string solutionConfiguration, string projectUniqueName,
        bool waitForPublishToFinish = false) =>
        throw new NotImplementedException();

    public void DeployProject(string solutionConfiguration, string projectUniqueName,
        bool waitForDeployToFinish = false) =>
        throw new NotImplementedException();

    #endregion
}
