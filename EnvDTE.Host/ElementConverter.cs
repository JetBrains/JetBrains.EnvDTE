using JetBrains.Annotations;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host
{
    public static class ElementConverter
    {
        [CanBeNull]
        public static string FindName(ITreeNode element) => element switch
        {
            IDeclaration declaration => declaration.DeclaredName,
            _ => null
        };

        public static int GetTypeId([NotNull] ITreeNode node) => node switch
        {
            ICSharpNamespaceDeclaration _ => 1,
            IClassDeclaration _ => 2,
            IStructDeclaration _ => 3,
            IInterfaceDeclaration _ => 4,
            IFunctionDeclaration _ => 5,
            _ => 0
        };
    }
}
