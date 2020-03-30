using JetBrains.Annotations;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host
{
    public static class ElementNameProvider
    {
        [CanBeNull]
        public static string FindName(ITreeNode element) => element switch
        {
            IDeclaration declaration => declaration.DeclaredName,
            _ => null
        };
    }
}
