using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.VB;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class FileCodeModelCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(ISolution solution, ProjectModelViewHost host, DteProtocolModel model)
        {
            model.FileCodeModel_get_Language.SetWithReadLock(projectItemModel => host
                    .GetItemById<IProjectFile>(projectItemModel.Id)
                    ?.ToSourceFile()
                    ?.PrimaryPsiLanguage switch
                    {
                        CSharpLanguage _ => LanguageModel.CSharp,
                        VBLanguage _ => LanguageModel.VB,
                        _ => LanguageModel.Unknown
                    }
            );
        }
    }
}
