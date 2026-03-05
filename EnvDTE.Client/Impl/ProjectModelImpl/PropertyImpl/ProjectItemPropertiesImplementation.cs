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

public class ProjectItemPropertiesImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] object parent,
    [NotNull] ProjectItemModel projectItemModel,
    ProjectItemKindModel itemKind)
    : PropertiesImplementation(dte, parent)
{
    private IReadOnlyDictionary<string, StringPropertyInfo> PropertyMap => VisualStudioProperties.GetItemKindSpecificMap(itemKind);

    public override int Count => PropertyMap.Count;

    public override Property Item(object index)
    {
        var map = PropertyMap;

        if (index is int intIndex)
        {
            var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, map.Count);
            var propertyInfoAtIndex = map.ElementAt(i).Value;
            return new ProjectItemPropertyImplementation(DteImplementation, this, projectItemModel, propertyInfoAtIndex);
        }

        if (index is string stringIndex && map.TryGetValue(stringIndex, out var propertyInfoByName))
            return new ProjectItemPropertyImplementation(DteImplementation, this, projectItemModel, propertyInfoByName);

        throw new ArgumentException(nameof(index));
    }

    public override IEnumerator GetEnumerator() => PropertyMap.Values
        .Select(info => new ProjectItemPropertyImplementation(DteImplementation, this, projectItemModel, info))
        .GetEnumerator();
}
