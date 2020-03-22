using System.Linq;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class CodeElementCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            ConnectionManager manager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        ) => model.CodeElement_get_Children.SetWithReadLock(codeElementModel =>
        {
            var astManager = manager.Hosts[codeElementModel.ContainingFile.Id];
            var query =
                from childId in astManager.GetChildren(codeElementModel.Id)
                let child = astManager.GetElement(childId)
                let childTypeId = ElementConverter.GetTypeId(child)
                let childName = ElementConverter.FindName(child)
                select new CodeElementModel(childName, childTypeId, codeElementModel.ContainingFile, childId);
            return query.ToList();
        });
    }
}
