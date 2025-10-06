using System;
using System.Collections;
using System.Linq;
using EnvDTE;
using JetBrains.EnvDTE.Client.Impl.Props.PropertyInfo;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Props;

public class ConfigurationPropertiesImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] object parent,
    [NotNull] Rider.Model.ProjectModel projectModel)
    : PropertiesImplementation(dte, parent)
{
    public override Property Item(object index)
    {
        var projectLanguage = DteImplementation.DteProtocolModel.Project_get_Language.Sync(projectModel);
        var languageSpecificMap = VisualStudioConfigurationProperties.GetLanguageSpecificMap(projectLanguage);

        StringPropertyInfo propertyInfo;
        switch (index)
        {
            case int intIndex:
            {
                var i = ImplementationUtil.GetValidIndexOrThrow(intIndex,
                    VisualStudioConfigurationProperties.Map.Count + languageSpecificMap.Count);
                propertyInfo = i >= VisualStudioConfigurationProperties.Map.Count
                    ? languageSpecificMap.ElementAt(i - VisualStudioConfigurationProperties.Map.Count).Value
                    : VisualStudioConfigurationProperties.Map.ElementAt(i).Value;
                break;
            }
            case string stringIndex:
            {
                if (!VisualStudioConfigurationProperties.Map.TryGetValue(stringIndex, out propertyInfo) &&
                    !languageSpecificMap.TryGetValue(stringIndex, out propertyInfo))
                    return new NullPropertyImplementation(DteImplementation, this, stringIndex);
                break;
            }
            default:
                throw new ArgumentException();
        }

        return new ProjectPropertyImplementation(DteImplementation, this, projectModel, propertyInfo);
    }

    public override int Count => VisualStudioProjectProperties.Map.Count;

    public override IEnumerator GetEnumerator()
    {
        var projectLanguage = DteImplementation.DteProtocolModel.Project_get_Language.Sync(projectModel);
        return VisualStudioConfigurationProperties.Map.Values
            .Concat(VisualStudioConfigurationProperties.GetLanguageSpecificMap(projectLanguage).Values)
            .Select(info => new ProjectPropertyImplementation(DteImplementation, this, projectModel, info))
            .GetEnumerator();
    }
}
