using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host.Manager
{
	public sealed class AstGeneratorProcessor : IRecursiveElementProcessor
	{
		[NotNull]
		private AbstractSyntaxTreeManager Manager { get; }

		public AstGeneratorProcessor([NotNull] AbstractSyntaxTreeManager manager) => Manager = manager;
		public bool ProcessingIsFinished => false;
		public bool InteriorShouldBeProcessed(ITreeNode element) => true;
		public void ProcessBeforeInterior(ITreeNode element)
		{
			if (!AstNodeFilter.ShouldUse(element)) return;
			Manager.AddElement(element);
		}

		public void ProcessAfterInterior(ITreeNode element)
		{
		}
	}
}
