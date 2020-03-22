using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Ast;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Model
{
	public sealed class ModelElementConverter
	{
		private DteImplementation Implementation { get; }
		public ModelElementConverter(DteImplementation implementation) => Implementation = implementation;

		[CanBeNull]
		public CodeElement Convert([NotNull] CodeElementModel model) => model.TypeId switch
		{
			1 => new CodeNamespaceImpl(Implementation, model),
			2 => new CodeClassImpl(Implementation, model),
			3 => new CodeStructImpl(Implementation, model),
			4 => new CodeInterfaceImpl(Implementation, model),
			5 => new CodeFunctionImpl(Implementation, model),
			_ => null
		};
	}
}
