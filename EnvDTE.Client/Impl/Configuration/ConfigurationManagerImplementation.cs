using System;
using System.Collections;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Configuration;

public class ConfigurationManagerImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] Rider.Model.ProjectModel parent) : ConfigurationManager
{
    public DTE DTE => dte;
    public object Parent => parent;

    public int Count => dte.DteProtocolModel.Project_get_ConfigurationCount.Sync(parent);
    public object ConfigurationRowNames => dte.DteProtocolModel.Project_get_ConfigurationNames.Sync(parent);
    public object PlatformNames => dte.DteProtocolModel.Project_get_PlatformNames.Sync(parent);

    public global::EnvDTE.Configuration ActiveConfiguration { get; }

    #region NotImplemented

    public object SupportedPlatforms => throw new NotImplementedException();

    public global::EnvDTE.Configuration Item(object index, string platform = "") => throw new NotImplementedException();

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
