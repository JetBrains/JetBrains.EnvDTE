using System;
using System.Collections;
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
    [NotNull] ProjectItemModel projectItemModel)
    : PropertiesImplementation(dte, parent)
{
    public override int Count => VisualStudioProperties.ProjectItemPropertiesMap.Count;

    public override Property Item(object index)
    {
        var map = VisualStudioProperties.ProjectItemPropertiesMap;

        if (index is int intIndex)
        {
            var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, map.Count);
            var propertyInfoAtIndex = map.ElementAt(i).Value;
            return new ProjectItemPropertyImplementation(DteImplementation, this, projectItemModel, propertyInfoAtIndex);
        }

        if (index is string stringIndex)
        {
            return map.TryGetValue(stringIndex, out var propertyInfoByName)
                ? new ProjectItemPropertyImplementation(DteImplementation, this, projectItemModel, propertyInfoByName)
                : new NullPropertyImplementation(DteImplementation, this, stringIndex);
        }

        throw new ArgumentException(nameof(index));
    }

    public override IEnumerator GetEnumerator() => VisualStudioProperties.ProjectItemPropertiesMap.Values.Select(info =>
        new ProjectItemPropertyImplementation(DteImplementation, this, projectItemModel, info)).GetEnumerator();
}
