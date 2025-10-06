using System;
using System.Collections;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.ConfigurationImpl;

public class ConfigurationManagerImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] Rider.Model.ProjectModel project)
    : ConfigurationManager
{
    [CanBeNull] private Configuration _activeConfiguration;
    public DTE DTE => dte;
    public object Parent => project;

    public int Count => dte.DteProtocolModel.Project_get_ConfigurationCount.Sync(project);
    public object ConfigurationRowNames => dte.DteProtocolModel.Project_get_ConfigurationNames.Sync(project);
    public object PlatformNames => dte.DteProtocolModel.Project_get_PlatformNames.Sync(project);

    public Configuration ActiveConfiguration {
        get
        {
            _activeConfiguration ??= new ProjectActiveConfigurationImplementation(dte, this, project);
            return _activeConfiguration;
        }
    }

    #region NotImplemented

    public object SupportedPlatforms => throw new NotImplementedException();

    public Configuration Item(object index, string platform = "") => throw new NotImplementedException();

    public Configurations ConfigurationRow(string name) => throw new NotImplementedException();

    public Configurations AddConfigurationRow(string newName, string existingName, bool propagate) =>
        throw new NotImplementedException();
    public void DeleteConfigurationRow(string name) => throw new NotImplementedException();

    public Configurations Platform(string name) => throw new NotImplementedException();

    public Configurations AddPlatform(string newName, string existingName, bool propagate) =>
        throw new NotImplementedException();

    public void DeletePlatform(string name) => throw new NotImplementedException();

    public IEnumerator GetEnumerator() => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}
