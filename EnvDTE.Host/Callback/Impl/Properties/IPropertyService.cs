using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Lifetimes;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Properties;

public interface IPropertyService<in TTarget> where TTarget : class
{
    [CanBeNull]
    public Task<string> GetPropertyAsync(
        Lifetime lifetime,
        [NotNull] TTarget project,
        [NotNull] string propertyName);

    public Task SetPropertyAsync(
        Lifetime lifetime,
        [NotNull] TTarget project,
        [NotNull] string propertyName,
        [CanBeNull] string propertyValue);

    public bool IsValidProperty([NotNull] string propertyName);
}
