using System;
using JetBrains.Annotations;
using JetBrains.Application.Parts;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host.Manager
{
    /// <summary>
    /// Maintains the ids to be used in protocol AST
    /// </summary>
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public class AstManager
    {
        [NotNull]
        private AstContainer<IDeclaredElement> DetachedAstContainer { get; }

        [NotNull]
        private AstContainer<ITreeNode> PsiContainer { get; }

        [NotNull]
        private AstContainer<IArrayType> TypeContainer { get; }

        public AstManager()
        {
            var source = new IdSource();
            DetachedAstContainer = new AstContainer<IDeclaredElement>(source);
            PsiContainer = new AstContainer<ITreeNode>(source);
            TypeContainer = new AstContainer<IArrayType>(source);
        }

        [NotNull]
        public TResult MapElement<TNode, TElement, TResult>(
            int id,
            [NotNull] Func<TNode, TResult> psiMapper,
            [NotNull] Func<TElement, TResult> declaredElementMapper,
            [NotNull] Func<IArrayType, TResult> typeMapper
        )
            where TNode : ITreeNode
            where TElement : IDeclaredElement =>
            TryMapWith(id, PsiContainer, psiMapper)
            ?? TryMapWith(id, DetachedAstContainer, declaredElementMapper)
            ?? TryMapWith(id, TypeContainer, typeMapper)
            ?? throw new InvalidOperationException($"Attempted to map non-existing element with id {id}");

        [CanBeNull]
        private static TResult TryMapWith<TNode, TBaseNode, TResult>(
            int id,
            [NotNull] AstContainer<TBaseNode> container,
            [NotNull] Func<TNode, TResult> mapper
        )
            where TNode : TBaseNode
            where TBaseNode : class
        {
            var node = container.TryGetElement(id);
            if (node == null) return default;
            if (node is TNode correct) return mapper(correct);
            throw new InvalidOperationException($"Wrong node type. Expected {typeof(TNode)}, actual {node.GetType()}");
        }

        public int GetOrCreateId([NotNull] ITreeNode node) => PsiContainer.GetOrCreateId(node);
        public int GetOrCreateId([NotNull] IDeclaredElement element) => DetachedAstContainer.GetOrCreateId(element);
        public int GetOrCreateId([NotNull] IArrayType type) => TypeContainer.GetOrCreateId(type);
    }
}
