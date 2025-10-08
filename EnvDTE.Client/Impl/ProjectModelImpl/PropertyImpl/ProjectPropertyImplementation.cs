using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.Exceptions;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;

// Doesn't work for CPP projects
public class ProjectPropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] ProjectItemModel projectModel,
    [NotNull] StringPropertyInfo propertyInfo)
    : ScalarPropertyImplementation(dte, parent, propertyInfo.VisualStudioName)
{
    public override object Value
    {
        get
        {
            var value = DteImplementation.DteProtocolModel.Project_get_Property.Sync(
                new(propertyInfo.RiderName, projectModel));

            return propertyInfo.ParseValue(value);
        }
        set
        {
            if (propertyInfo.IsReadOnly) throw new SetReadOnlyPropertyException();

            var canonicalValue = propertyInfo.GetCanonicalValueOrThrow(value);
            DteImplementation.DteProtocolModel.Project_set_Property.Sync(
                new(propertyInfo.RiderName, canonicalValue, projectModel));
        }
    }
}
