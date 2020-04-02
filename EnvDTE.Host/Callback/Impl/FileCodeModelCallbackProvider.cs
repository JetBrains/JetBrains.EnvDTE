using System.Collections.Generic;
using System.Linq;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class FileCodeModelCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            GlobalAstManager globalAstManager,
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

                var abstractSyntaxTreeHost = globalAstManager.GetOrCreate(projectFile);
                int psiFileId = abstractSyntaxTreeHost.GetId(psiFile);
                var query =
                    from childId in abstractSyntaxTreeHost.GetChildren(psiFileId)
                    let child = abstractSyntaxTreeHost.GetElement(childId)
                    let childTypeId = PsiElementRegistrar.GetTypeId(child)
                    select new CodeElementModel(childTypeId, projectItemModel, childId);
                return query.ToList();
            });
        }
    }
}
