using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.Collections.Viewable;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback
{
    [DerivedComponentsInstantiationRequirement(InstantiationRequirement.DeadlockSafe)]
    public interface IEnvDteCallbackProvider
    {
        void RegisterCallbacks([NotNull] DteProtocolModel model, [NotNull] IScheduler scheduler);
    }
}
