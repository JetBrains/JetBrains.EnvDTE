using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Manager
{
    public sealed class AstContainer<TNode>
    {
        [NotNull]
        private IdSource IdSource { get; }

        [NotNull]
        private IDictionary<int, TNode> IdToNodeMap { get; } = new Dictionary<int, TNode>();

        [NotNull]
        private IDictionary<TNode, int> NodeToIdMap { get; } = new Dictionary<TNode, int>();

        public AstContainer([NotNull] IdSource idSource) => IdSource = idSource;

        [CanBeNull]
        public TNode TryGetElement(int id) => IdToNodeMap.TryGetValue(id);

        public int GetOrCreateId([NotNull] TNode node)
        {
            if (NodeToIdMap.TryGetValue(node, out int result)) return result;
            RegisterElement(node);
            return NodeToIdMap[node];
        }

        private void RegisterElement([NotNull] TNode node)
        {
            int id = IdSource.GenerateNewId();
            IdToNodeMap[id] = node;
            NodeToIdMap[node] = id;
        }
    }
}
