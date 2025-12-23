using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;

public class ConfigurationPropertiesImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] object parent,
    [NotNull] ProjectItemModel projectModel)
    : PropertiesImplementation(dte, parent)
{
    private IReadOnlyDictionary<string, StringPropertyInfo> LanguageSpecificMap
    {
        get
        {
            var projectLanguage = DteImplementation.DteProtocolModel.Project_get_Language.Sync(new(projectModel));
            return VisualStudioProperties.GetLanguageSpecificConfigurationMap(projectLanguage);
        }
    }

    public override Property Item(object index)
    {
        var baseMap = VisualStudioProperties.ConfigurationPropertiesMap;
        var languageSpecificMap = LanguageSpecificMap;

        if (index is int intIndex)
        {
            var total = baseMap.Count + languageSpecificMap.Count;
            var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, total);

            var propertyInfoAtIndex = i >= baseMap.Count
                ? languageSpecificMap.ElementAt(i - baseMap.Count).Value
                : baseMap.ElementAt(i).Value;

            return new ProjectPropertyImplementation(DteImplementation, this, projectModel, propertyInfoAtIndex);
        }

        if (index is string stringIndex)
        {
            if (baseMap.TryGetValue(stringIndex, out var baseInfo))
                return new ProjectPropertyImplementation(DteImplementation, this, projectModel, baseInfo);

            if (languageSpecificMap.TryGetValue(stringIndex, out var langInfo))
                return new ProjectPropertyImplementation(DteImplementation, this, projectModel, langInfo);
        }

        throw new ArgumentException(nameof(index));
    }

    public override int Count => VisualStudioProperties.ConfigurationPropertiesMap.Count + LanguageSpecificMap.Count;

    public override IEnumerator GetEnumerator()
    {
        var projectLanguage = DteImplementation.DteProtocolModel.Project_get_Language.Sync(new(projectModel));
        return VisualStudioProperties.ConfigurationPropertiesMap.Values
            .Concat(VisualStudioProperties.GetLanguageSpecificConfigurationMap(projectLanguage).Values)
            .Select(info => new ProjectPropertyImplementation(DteImplementation, this, projectModel, info))
            .GetEnumerator();
    }
}
