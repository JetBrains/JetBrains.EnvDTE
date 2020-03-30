using System.Collections.Generic;
using System.Linq;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.ReSharper.Psi.VB;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class FileCodeModelCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            ConnectionManager connectionManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            model.FileCodeModel_get_CodeElements.SetWithReadLock(projectItemModel =>
            {
                var psiFile = host
                    .GetItemById<IProjectFile>(projectItemModel.Id)
                    ?.ToSourceFile()
                    ?.GetPrimaryPsiFile();
                if (psiFile == null) return new List<CodeElementModel>();

                var abstractSyntaxTreeHost = connectionManager.AstManagers.GetOrCreateValue(projectItemModel.Id, () =>
                {
                    var astManager = new AstManager();
                    // TODO: support other languages, too
                    if (!(psiFile is ICSharpFile csharpFile)) return null;
                    astManager.Initialize(csharpFile);
                    return astManager;
                });
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
