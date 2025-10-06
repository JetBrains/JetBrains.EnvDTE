using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.PropertiesImpl.Exceptions;
using JetBrains.EnvDTE.Client.Impl.PropertiesImpl.PropertyInfo;

namespace JetBrains.EnvDTE.Client.Impl.PropertiesImpl;

// Doesn't work for CPP projects
public class ProjectPropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] Rider.Model.ProjectModel projectModel,
    [NotNull] StringPropertyInfo propertyInfo)
    : ScalarPropertyImplementation(dte, parent, propertyInfo.VisualStudioName)
{
    public override object Value
    {
        get
        {
            var value = DteImplementation.DteProtocolModel.Project_get_Property.Sync(
                new(projectModel, propertyInfo.RiderName));

            return propertyInfo.ParseValue(value);
        }
        set
        {
            if (propertyInfo.IsReadOnly) throw new SetReadOnlyPropertyException();

            var canonicalValue = propertyInfo.GetCanonicalValueOrThrow(value);
            DteImplementation.DteProtocolModel.Project_set_Property.Sync(
                new(projectModel, propertyInfo.RiderName, canonicalValue));
        }
    }
}
