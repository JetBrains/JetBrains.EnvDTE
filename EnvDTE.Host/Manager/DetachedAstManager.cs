using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;

namespace JetBrains.EnvDTE.Host.Manager
{
    public sealed class DetachedAstManager
    {
        [NotNull]
        private IdSource IdSource { get; }

        [NotNull]
        private IDictionary<int, IDeclaredElement> IdToNodeMap { get; } = new Dictionary<int, IDeclaredElement>();

        [NotNull]
        private IDictionary<IDeclaredElement, int> NodeToIdMap { get; } = new Dictionary<IDeclaredElement, int>();

        public DetachedAstManager([NotNull] IdSource idSource) => IdSource = idSource;

        [NotNull]
        public IDeclaredElement GetElement(int id) => IdToNodeMap[id];

        public int GetOrCreateId([NotNull] IDeclaredElement node)
        {
            if (NodeToIdMap.TryGetValue(node, out int result)) return result;
            RegisterElement(node);
            return NodeToIdMap[node];
        }

        private void RegisterElement([NotNull] IDeclaredElement node)
        {
            int id = IdSource.GenerateNewId();
            IdToNodeMap[id] = node;
            NodeToIdMap[node] = id;
        }
    }
}
