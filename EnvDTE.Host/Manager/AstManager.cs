using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Diagnostics;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Manager
{
	public sealed class AstManager
	{
		private IdSource IdSource { get; } = new IdSource();
		private IDictionary<int, ITreeNode> IdToNodeMap { get; } = new Dictionary<int, ITreeNode>();

		public void AddElement([NotNull] ITreeNode node)
		{
			int id = IdSource.GenerateNewId();
			IdToNodeMap[id] = node;
			node.UserData.PutData(EnvDTEId, new ConstIntReference(id));
		}

		public void Initialize([NotNull] ICSharpFile file) =>
			file.ProcessThisAndDescendants(new AstGeneratorProcessor(this));

		public ITreeNode GetElement(int id) => IdToNodeMap[id];

		[NotNull]
		public List<int> GetChildren(int id) =>
			IdToNodeMap[id].Children().Where(AstNodeFilter.ShouldUse).Select(GetId).AsList();

		public int GetId([NotNull] ITreeNode node) => node.UserData.GetData(EnvDTEId).NotNull().Value;

		private static Key<ConstIntReference> EnvDTEId { get; } =
			new Key<ConstIntReference>("JetBrains EnvDTE Host AST Element ID");
	}
}
