using System;
using System.Collections;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Props.PropertyInfo;
using JetBrains.EnvDTE.Client.Util;

namespace JetBrains.EnvDTE.Client.Impl.Props;

public class ProjectPropertiesImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] object parent,
    [NotNull] Rider.Model.ProjectModel projectModel)
    : PropertiesImplementation(dte, parent)
{
    public override Property Item(object index)
    {
        StringPropertyInfo propertyInfo;
        switch (index)
        {
            case int intIndex:
            {
                var i = ImplementationUtil.GetValidIndexOrThrow(intIndex, VisualStudioProperties.Map.Count);
                propertyInfo = VisualStudioProperties.Map.ElementAt(i).Value;
                break;
            }
            case string stringIndex:
            {
                if (!VisualStudioProperties.Map.TryGetValue(stringIndex, out propertyInfo))
                    return new NullPropertyImplementation(DteImplementation, this, stringIndex);
                break;
            }
            default:
                throw new ArgumentException();
        }

        return new ProjectPropertyImplementation(DteImplementation, this, projectModel, propertyInfo);
    }

    public override int Count => VisualStudioProperties.Map.Count;

    public override IEnumerator GetEnumerator() => VisualStudioProperties.Map.Values.Select(info =>
        new ProjectPropertyImplementation(DteImplementation, this, projectModel, info)).GetEnumerator();
}
