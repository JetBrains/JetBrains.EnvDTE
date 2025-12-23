using System;
using System.Collections;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;

public class ProjectPropertiesImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] object parent,
    [NotNull] ProjectItemModel projectModel)
    : PropertiesImplementation(dte, parent)
{
    public override Property Item(object index)
    {
        // In VS behavior of this method for Project properties differs from other implementations of the same method.
        // If an integer index is out of range, an exception is thrown, but if a string index is invalid, a null property is returned
        var map = VisualStudioProperties.ProjectPropertiesMap;

        if (index is int intIndex)
        {
            var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, map.Count);
            var propertyInfoAtIndex = map.ElementAt(i).Value;
            return new ProjectPropertyImplementation(DteImplementation, this, projectModel, propertyInfoAtIndex);
        }

        if (index is string stringIndex)
        {
            return map.TryGetValue(stringIndex, out var propertyInfoByName)
                ? new ProjectPropertyImplementation(DteImplementation, this, projectModel, propertyInfoByName)
                : new NullPropertyImplementation(DteImplementation, this, stringIndex);
        }

        throw new ArgumentException(nameof(index));
    }

    public override int Count => VisualStudioProperties.ProjectPropertiesMap.Count;

    public override IEnumerator GetEnumerator() => VisualStudioProperties.ProjectPropertiesMap.Values.Select(info =>
        new ProjectPropertyImplementation(DteImplementation, this, projectModel, info)).GetEnumerator();
}
