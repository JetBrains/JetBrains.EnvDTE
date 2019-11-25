using JetBrains.Annotations;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback
{
    public interface IEnvDteCallbackProvider
    {
        void RegisterCallbacks(
            [NotNull] ISolution solution,
            [NotNull] ProjectModelViewHost host,
            [NotNull] DteProtocolModel model
        );
    }
}
