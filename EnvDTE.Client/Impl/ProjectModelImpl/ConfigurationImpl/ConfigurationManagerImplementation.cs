using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.ConfigurationImpl;

public class ConfigurationManagerImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] ProjectItemModel parentItemModel)
    : ConfigurationManager
{
    [CanBeNull] private Configuration _activeConfiguration;

    public DTE DTE => dte;
    public object Parent => parentItemModel;

    public int Count => dte.DteProtocolModel.Project_get_ConfigurationCount.Sync(new (parentItemModel));
    public object ConfigurationRowNames => dte.DteProtocolModel.Project_get_ConfigurationNames.Sync(new (parentItemModel));
    public object PlatformNames => dte.DteProtocolModel.Project_get_PlatformNames.Sync(new (parentItemModel));

    public Configuration ActiveConfiguration {
        get
        {
            _activeConfiguration ??= new ProjectActiveConfigurationImplementation(dte, this, parentItemModel);
            return _activeConfiguration;
        }
    }

    // TODO: This should enumerate all configurations, not just the active one
    public IEnumerator GetEnumerator() => new List<Configuration>([ActiveConfiguration]).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

    #endregion
}
