using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host
{
    public sealed class GlobalAstManager
    {
        [NotNull]
        private ProjectModelViewHost Host { get; }

        [NotNull]
        private IdSource Source { get; }

        [NotNull]
        private IDictionary<int, AstManager> AstManagers { get; }

        [NotNull]
        private DetachedAstManager DetachedAstManager { get; }

        public GlobalAstManager([NotNull] ProjectModelViewHost host)
        {
            Host = host;
            Source = new IdSource();
            AstManagers = new Dictionary<int, AstManager>();
            DetachedAstManager = new DetachedAstManager(Source);
        }

        public AstManager GetOrCreate([NotNull] IProjectFile projectFile) =>
            AstManagers.GetOrCreateValue(Host.GetIdByItem(projectFile), () => new AstManager(Source));
    }
}
