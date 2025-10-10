using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.Exceptions;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl;

public abstract class PropertyImplementation(
    [NotNull] DteImplementation dte,
    [NotNull] PropertiesImplementation parent,
    [NotNull] StringPropertyInfo propertyInfo) 
    : ScalarPropertyImplementation(dte, parent, propertyInfo.VisualStudioName)
{
    public override object Value
    {
        get
        {
            var value = GetRawValue(propertyInfo.RiderName);
            return propertyInfo.ParseValue(value);
        }
        set
        {
            if (propertyInfo.IsReadOnly) throw new SetReadOnlyPropertyException();

            var canonicalValue = propertyInfo.GetCanonicalValueOrThrow(value);
            SetRawValue(propertyInfo.RiderName, canonicalValue);
        }
    }

    [CanBeNull] protected abstract string GetRawValue(string name);
    protected abstract void SetRawValue(string name, [CanBeNull] string value);
}
