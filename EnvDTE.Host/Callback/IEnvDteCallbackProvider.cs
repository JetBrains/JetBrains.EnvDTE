using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback
{
    [DerivedComponentsInstantiationRequirement(InstantiationRequirement.DeadlockSafe)]
    public interface IEnvDteCallbackProvider
    {
        void RegisterCallbacks([NotNull] DteProtocolModel model);
    }
}
