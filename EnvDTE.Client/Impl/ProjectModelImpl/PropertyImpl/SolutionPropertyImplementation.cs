using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;

public class SolutionPropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] StringPropertyInfo propertyInfo)
    : PropertyImplementation(dte, parent, propertyInfo)
{
    protected override string GetRawValue(string name) =>
        DteImplementation.DteProtocolModel.Solution_get_Property.Sync(name);

    protected override void SetRawValue(string name, string value) =>
        DteImplementation.DteProtocolModel.Solution_set_Property.Sync(new(name, value));
}
