using System;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Props;

namespace JetBrains.EnvDTE.Client.Impl.Configuration;

public class ProjectActiveConfigurationImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] ConfigurationManagerImplementation parent,
    [NotNull] Rider.Model.ProjectModel project)
    : global::EnvDTE.Configuration
{
    [CanBeNull] private ConfigurationPropertiesImplementation _properties;

    public DTE DTE => dte;
    public ConfigurationManager Collection => parent;
    public object Object => this;
    public object Owner => parent.Parent;
    public vsConfigurationType Type => vsConfigurationType.vsConfigurationTypeProject;

    public string ConfigurationName => dte.DteProtocolModel.Project_get_ActiveConfigName.Sync(project);
    public string PlatformName => dte.DteProtocolModel.Project_get_ActiveConfigPlatformName.Sync(project);

    public Properties Properties
    {
        get
        {
            _properties ??= new ConfigurationPropertiesImplementation(dte, this, project);
            return _properties;
        }
    }

    public bool IsBuildable => dte.DteProtocolModel.Project_get_IsBuildable.Sync(project);
    public bool IsDeployable => dte.DteProtocolModel.Project_get_IsDeployable.Sync(project);

    #region NotImplemented

    public bool IsRunable => throw new NotImplementedException();
    public object ExtenderNames => throw new NotImplementedException();
    public string ExtenderCATID => throw new NotImplementedException();
    public OutputGroups OutputGroups => throw new NotImplementedException();
    public object get_Extender(string extenderName) => throw new NotImplementedException();

    #endregion
}
