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
        var map = VisualStudioProjectProperties.Map;

        StringPropertyInfo propertyInfo;
        switch (index)
        {
            case int intIndex:
            {
                var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, map.Count);
                propertyInfo = map.ElementAt(i).Value;
                break;
            }
            case string stringIndex:
            {
                if (!map.TryGetValue(stringIndex, out propertyInfo))
                    return new NullPropertyImplementation(DteImplementation, this, stringIndex);
                break;
            }
            default:
                throw new ArgumentException();
        }

        return new ProjectPropertyImplementation(DteImplementation, this, projectModel, propertyInfo);
    }

    public override int Count => VisualStudioProjectProperties.Map.Count;

    public override IEnumerator GetEnumerator() => VisualStudioProjectProperties.Map.Values.Select(info =>
        new ProjectPropertyImplementation(DteImplementation, this, projectModel, info)).GetEnumerator();
}
