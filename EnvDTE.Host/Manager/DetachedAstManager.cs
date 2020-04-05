using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Manager
{
    public sealed class DetachedAstManager
    {
        private ILogger Logger { get; } = JetBrains.Util.Logging.Logger.GetLogger<DetachedAstManager>();

        [NotNull]
        private IdSource IdSource { get; }

        [NotNull]
        private IDictionary<int, object> IdToNodeMap { get; } = new Dictionary<int, object>();

        [NotNull]
        private OneToListMap<int, int> IdToChildrenMap { get; } = new OneToListMap<int, int>();

        [NotNull]
        private IDictionary<object, int> NodeToIdMap { get; } = new Dictionary<object, int>();

        private object GetElement(int id) => IdToNodeMap[id];

        private int GetOrCreateId([NotNull] object node, object parent)
        {
            if (NodeToIdMap.TryGetValue(node, out int result)) return result;
            throw new NotImplementedException();
        }

        private void Initialize([NotNull] ITypeElement node)
        {
            RegisterElement(node);
            foreach (var member in node.GetMembers())
            {
                VisitMember(member);
            }
        }

        private void VisitMember([NotNull] ITypeMember member)
        {
            RegisterElement(member);
        }

        private void AddElement([NotNull] object node, [NotNull] object parent)
        {
            RegisterElement(node);

        }

        private void RegisterElement([NotNull] object node)
        {
            int id = IdSource.GenerateNewId();
            IdToNodeMap[id] = node;
            NodeToIdMap[node] = id;
        }

        public DetachedAstManager([NotNull] IdSource idSource) => IdSource = idSource;
    }
}
