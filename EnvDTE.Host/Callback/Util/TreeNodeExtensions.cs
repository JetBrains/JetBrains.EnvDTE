using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host.Callback.Util
{
    public static class TreeNodeExtensions
    {
        [CanBeNull]
        public static string FindName(this ITreeNode element) => element switch
        {
            IDeclaration declaration => declaration.DeclaredName,
            IAttribute attribute => attribute.Name.ShortName,
            _ => null
        };

        [NotNull, ItemNotNull]
        public static IEnumerable<ITreeNode> GetEnvDTEModelChildren([NotNull] this ITreeNode node)
        {
            foreach (var directChild in node.Children())
            {
                if (PsiElementRegistrar.ShouldAddToModel(directChild))
                {
                    yield return directChild;
                }
                else if (PsiElementRegistrar.ShouldVisitChildren(directChild))
                {
                    foreach (var modelChild in GetEnvDTEModelChildren(directChild))
                    {
                        yield return modelChild;
                    }
                }
            }
        }

        [CanBeNull]
        public static ITreeNode GetEnvDTEModelParent([NotNull] this ITreeNode node)
        {
            var current = node;
            do
            {
                if (PsiElementRegistrar.ShouldAddToModel(current)) return current;
                current = current.Parent;
            }
            while (current != null);

            return null;
        }
    }
}
