using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Ast
{
    [SolutionComponent(InstantiationEx.LegacyDefault)]
    public sealed class FileCodeModelCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            AstManager astManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            model.FileCodeModel_get_CodeElements.SetWithReadLock(projectItemModel =>
            {
                var projectFile = host.GetItemById<IProjectFile>(projectItemModel.Id);
                var psiFile = projectFile
                    ?.ToSourceFile()
                    ?.GetPrimaryPsiFile();
                if (psiFile == null) return new List<CodeElementModel>();

                var query =
                    from child in psiFile.GetEnvDTEModelChildren()
                    let childId = astManager.GetOrCreateId(child)
                    let childTypeId = PsiElementRegistrar.GetTypeId(child)
                    select new CodeElementModel(childTypeId, childId);
                return query.ToList();
            });
        }
    }
}
