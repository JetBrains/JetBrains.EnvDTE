using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Util;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Manager
{
    /// <summary>
    /// Maintains the ids to be used in protocol AST
    /// </summary>
    public sealed class AstManager
    {
        [NotNull]
        private IdSource IdSource { get; }

        [NotNull]
        private IDictionary<int, ITreeNode> IdToNodeMap { get; } = new Dictionary<int, ITreeNode>();

        public AstManager([NotNull] IdSource idSource) => IdSource = idSource;

        private void RegisterElement([NotNull] ITreeNode node)
        {
            int id = IdSource.GenerateNewId();
            IdToNodeMap[id] = node;
            node.UserData.PutData(EnvDTEId, new ImmutableReference<int>(id));
        }

        public ITreeNode GetElement(int id) => IdToNodeMap[id];

        public int GetOrCreateId([NotNull] ITreeNode node)
        {
            int? id = GetId(node);
            if (id != null) return id.Value;
            RegisterElement(node);
            return GetId(node).NotNull("Could not register a node");
        }

        private static int? GetId([NotNull] ITreeNode node) => node
            .UserData
            .GetData(EnvDTEId)?
            .Value;

        private static Key<ImmutableReference<int>> EnvDTEId { get; } =
            new Key<ImmutableReference<int>>("JetBrains EnvDTE Host AST Element ID");
    }
}
