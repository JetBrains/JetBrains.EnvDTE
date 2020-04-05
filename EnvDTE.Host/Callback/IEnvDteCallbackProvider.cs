using JetBrains.Annotations;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback
{
    public interface IEnvDteCallbackProvider
    {
        void RegisterCallbacks(
            [NotNull] AstManager astManager,
            [NotNull] ISolution solution,
            [NotNull] ProjectModelViewHost host,
            [NotNull] DteProtocolModel model
        );
    }
}
