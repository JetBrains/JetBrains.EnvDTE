using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Lifetimes;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Properties;

[DerivedComponentsInstantiationRequirement(InstantiationRequirement.DeadlockSafe)]
public interface IPropertyService<in TTarget> where TTarget : class
{
    [ItemCanBeNull]
    public Task<string> GetPropertyAsync(
        Lifetime lifetime,
        [NotNull] TTarget project,
        [NotNull] string propertyName);

    public Task SetPropertyAsync(
        Lifetime lifetime,
        [NotNull] TTarget project,
        [NotNull] string propertyName,
        [CanBeNull] string propertyValue);

    public RdPropertyType GetPropertyType([NotNull] string propertyName);
}
