using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;

public class ProjectPropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] ProjectItemModel projectModel,
    [NotNull] StringPropertyInfo propertyInfo)
    : PropertyImplementation(dte, parent, propertyInfo)
{
    protected override void SetRawValue(string name, string value) =>
        DteImplementation.DteProtocolModel.Project_set_Property.Sync(new(name, value, projectModel));

    protected override string GetRawValue(string name) =>
        DteImplementation.DteProtocolModel.Project_get_Property.Sync(new(name, projectModel));
}
