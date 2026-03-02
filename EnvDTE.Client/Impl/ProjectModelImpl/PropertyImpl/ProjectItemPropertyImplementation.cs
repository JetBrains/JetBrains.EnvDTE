using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;

public class ProjectItemPropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] ProjectItemModel projectItemModel,
    [NotNull] StringPropertyInfo propertyInfo)
    : PropertyImplementation(dte, parent, propertyInfo)
{
    protected override string GetRawValue(string name) =>
        DteImplementation.DteProtocolModel.ProjectItem_get_Property.Sync(new (name, projectItemModel));

    protected override void SetRawValue(string name, string value) =>
        DteImplementation.DteProtocolModel.ProjectItem_set_Property.Sync(new (name, value, projectItemModel));
}
