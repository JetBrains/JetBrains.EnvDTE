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
            return VisualStudioConfigurationProperties.GetLanguageSpecificMap(projectLanguage);
        }
    }

    public override Property Item(object index)
    {
        var languageSpecificMap = LanguageSpecificMap;
        var baseMap = VisualStudioConfigurationProperties.Map;

        StringPropertyInfo propertyInfo;
        switch (index)
        {
            case int intIndex:
            {
                var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, baseMap.Count + languageSpecificMap.Count);
                propertyInfo = i >= baseMap.Count
                    ? languageSpecificMap.ElementAt(i - baseMap.Count).Value
                    : baseMap.ElementAt(i).Value;
                break;
            }
            case string stringIndex:
            {
                if (!baseMap.TryGetValue(stringIndex, out propertyInfo) && !languageSpecificMap.TryGetValue(stringIndex, out propertyInfo))
                    return new NullPropertyImplementation(DteImplementation, this, stringIndex);
                break;
            }
            default:
                throw new ArgumentException();
        }

        return new ProjectPropertyImplementation(DteImplementation, this, projectModel, propertyInfo);
    }

    public override int Count => VisualStudioConfigurationProperties.Map.Count + LanguageSpecificMap.Count;

    public override IEnumerator GetEnumerator()
    {
        var projectLanguage = DteImplementation.DteProtocolModel.Project_get_Language.Sync(new(projectModel));
        return VisualStudioConfigurationProperties.Map.Values
            .Concat(VisualStudioConfigurationProperties.GetLanguageSpecificMap(projectLanguage).Values)
            .Select(info => new ProjectPropertyImplementation(DteImplementation, this, projectModel, info))
            .GetEnumerator();
    }
}
