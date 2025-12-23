using System;
using System.Collections;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;
using JetBrains.EnvDTE.Client.Util;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;

public class SolutionPropertiesImplementation([NotNull] DteImplementation dte, [NotNull] object parent)
    : PropertiesImplementation(dte, parent)
{
    public override Property Item(object index)
    {
        var map = VisualStudioProperties.SolutionPropertiesMap;

        if (index is int intIndex)
        {
            var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, map.Count);
            var propertyInfoAtIndex = map.ElementAt(i).Value;
            return new SolutionPropertyImplementation(DteImplementation, this, propertyInfoAtIndex);
        }

        if (index is string stringIndex && map.TryGetValue(stringIndex, out var propertyInfoByName))
            return new SolutionPropertyImplementation(DteImplementation, this, propertyInfoByName);

        throw new ArgumentException(nameof(index));
    }

    public override int Count => VisualStudioProperties.SolutionPropertiesMap.Count;

    public override IEnumerator GetEnumerator() => VisualStudioProperties.SolutionPropertiesMap.Values.Select(info =>
        new SolutionPropertyImplementation(DteImplementation, this, info)).GetEnumerator();
}
