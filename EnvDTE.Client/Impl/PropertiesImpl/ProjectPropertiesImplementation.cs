using System;
using System.Collections;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.PropertiesImpl.PropertyInfo;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.PropertiesImpl;

public class ProjectPropertiesImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] object parent,
    [NotNull] ProjectItemModel projectModel)
    : PropertiesImplementation(dte, parent)
{
    public override Property Item(object index)
    {
        StringPropertyInfo propertyInfo;
        switch (index)
        {
            case int intIndex:
            {
                var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, VisualStudioProjectProperties.Map.Count);
                propertyInfo = VisualStudioProjectProperties.Map.ElementAt(i).Value;
                break;
            }
            case string stringIndex:
            {
                if (!VisualStudioProjectProperties.Map.TryGetValue(stringIndex, out propertyInfo))
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
