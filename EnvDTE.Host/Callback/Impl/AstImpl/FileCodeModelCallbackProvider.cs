using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.Collections.Viewable;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.AstImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public class FileCodeModelCallbackProvider( ProjectModelViewHost host, AstManager astManager)
        : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(DteProtocolModel model, IScheduler scheduler)
        {
            model.FileCodeModel_get_CodeElements.SetWithProjectFileAsync(host, (lifetime, _, projectFile) =>
                lifetime.StartReadActionAsync(() =>
                {
                    var psiFile = projectFile.ToSourceFile()?.GetPrimaryPsiFile();
                    if (psiFile is null) return new List<CodeElementModel>();

                    var query =
                        from child in psiFile.GetEnvDTEModelChildren()
                        let childId = astManager.GetOrCreateId(child)
                        let childTypeId = PsiElementRegistrar.GetTypeId(child)
                        select new CodeElementModel(childTypeId, childId);
                    return query.ToList();
                }));
        }
    }
}
