using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host.Manager
{
    public sealed class AstGeneratorProcessor : IRecursiveElementProcessor
    {
        [NotNull]
        private AstManager Manager { get; }

        public AstGeneratorProcessor([NotNull] AstManager manager) => Manager = manager;
        public bool ProcessingIsFinished => false;
        public bool InteriorShouldBeProcessed(ITreeNode element) => PsiElementRegistrar.ShouldVisitChildren(element);

        public void ProcessBeforeInterior(ITreeNode element)
        {
            if (!PsiElementRegistrar.ShouldAddToModel(element)) return;
            var parent = GetModelParent(element);
            Manager.AddElement(element, parent);
        }

        public void ProcessAfterInterior(ITreeNode element)
        {
        }

        [NotNull]
        private static ITreeNode GetModelParent([NotNull] ITreeNode node)
        {
            var previous = node;
            var current = node.Parent;
            while (current != null)
            {
                if (PsiElementRegistrar.ShouldAddToModel(current)) return current;
                previous = current;
                current = current.Parent;
            }

            return previous;
        }
    }
}
