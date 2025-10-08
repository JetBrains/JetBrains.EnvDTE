using System;
using System.Collections;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl;
using JetBrains.EnvDTE.Client.Util;

namespace JetBrains.EnvDTE.Client.Impl.ConfigurationImpl;

public class SolutionConfigurationsImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] SolutionBuildImplementation parent)
    : SolutionConfigurations
{
    public DTE DTE => dte;
    public SolutionBuild Parent => parent;
    public int Count => dte.DteProtocolModel.Solution_get_ConfigurationCount.Sync(Unit.Instance);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator GetEnumerator() => Enumerable.Range(1, Count).Select(i => Item(i)).GetEnumerator();

    public SolutionConfiguration Item(object index)
    {
        var config = index switch
        {
            int intIndex => dte.DteProtocolModel.Solution_get_ConfigurationByIndex.Sync(
                ImplementationUtil.GetValidIndexOrThrow(intIndex)),
            string stringIndex => dte.DteProtocolModel.Solution_get_ConfigurationByName.Sync(stringIndex),
            _ => null
        };

        return config is null
            ? throw new ArgumentException(nameof(index))
            : new SolutionConfigurationImplementation(dte, config, this);
    }

    #region NotImplemented

    public SolutionConfiguration Add(string newName, string existingName, bool propagate) =>
        throw new NotImplementedException();

    #endregion
}
