using JetBrains.Annotations;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host.Manager
{
	public static class AstNodeFilter
	{
		public static bool ShouldUse([NotNull] ITreeNode node) => !(node is IWhitespaceNode);
	}
}
