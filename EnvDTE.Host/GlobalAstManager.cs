using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Files;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host
{
    public sealed class GlobalAstManager
    {
        [NotNull]
        private ProjectModelViewHost Host { get; }

        [NotNull]
        private IDictionary<int, AstManager> AstManagers { get; } = new Dictionary<int, AstManager>();

        public GlobalAstManager([NotNull] ProjectModelViewHost host) => Host = host;

        public AstManager GetOrCreate([NotNull] IProjectFile projectFile)
        {
            int id = Host.GetIdByItem(projectFile);
            if (AstManagers.TryGetValue(id, out var existing)) return existing;
            return AstManagers.GetOrCreateValue(id, () =>
            {
                var astManager = new AstManager();
                var psiFile = Host
                    .GetItemById<IProjectFile>(id)
                    ?.ToSourceFile()
                    ?.GetPrimaryPsiFile();
                // TODO: support other languages, too
                if (!(psiFile is ICSharpFile csharpFile)) return null;
                astManager.Initialize(csharpFile);
                return astManager;
            });
        }
    }
}
