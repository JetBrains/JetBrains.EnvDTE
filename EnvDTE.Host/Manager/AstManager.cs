using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Util;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Manager
{
    /// <summary>
    /// Maintains the ids to be used in protocol AST
    /// </summary>
    public sealed class AstManager
    {
        private IdSource IdSource { get; } = new IdSource();
        private IDictionary<int, ITreeNode> IdToNodeMap { get; } = new Dictionary<int, ITreeNode>();
        private OneToListMap<int, int> IdToChildrenMap { get; } = new OneToListMap<int, int>();

        public void AddElement([NotNull] ITreeNode node, [NotNull] ITreeNode parent)
        {
            RegisterElement(node);
            int childId = GetId(node);
            int parentId = GetId(parent);
            IdToChildrenMap.Add(parentId, childId);
        }

        private void RegisterElement([NotNull] ITreeNode node)
        {
            int id = IdSource.GenerateNewId();
            IdToNodeMap[id] = node;
            node.UserData.PutData(EnvDTEId, new ImmutableReference<int>(id));
        }

        public void Initialize([NotNull] ICSharpFile file)
        {
            RegisterElement(file);
            file.ProcessDescendants(new AstGeneratorProcessor(this));
        }

        public ITreeNode GetElement(int id) => IdToNodeMap[id];

        [NotNull]
        public IEnumerable<int> GetChildren(int id) => IdToChildrenMap[id];

        public int GetId([NotNull] ITreeNode node) => node
            .UserData
            .GetData(EnvDTEId)
            .NotNull($"EnvDTE ID was requested for a node that hasnt been registered. Node: {node}")
            .Value;

        private static Key<ImmutableReference<int>> EnvDTEId { get; } =
            new Key<ImmutableReference<int>>("JetBrains EnvDTE Host AST Element ID");
    }
}
