using System;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl;
using JetBrains.EnvDTE.Client.Impl.AstImpl;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Util
{
	public sealed class EnvDTEElementRegistrar
	{
		[NotNull]
        public DteImplementation Implementation { get; }

		public EnvDTEElementRegistrar([NotNull] DteImplementation implementation) => Implementation = implementation;

		[NotNull]
        public CodeElement Convert([NotNull] CodeElementModel model, object parent) => model.TypeId switch
		{
			1 => new CodeNamespaceImpl(Implementation, model, parent),
			2 => new CodeClassImpl(Implementation, model, parent),
			3 => new CodeStructImpl(Implementation, model, parent),
			4 => new CodeInterfaceImpl(Implementation, model, parent),
			5 => new CodeFunctionImpl(Implementation, model, parent),
            6 => new CodeParameterImpl(Implementation, model, parent),
            7 => new CodeAttributeImpl(Implementation, model, parent),
			_ => throw new InvalidOperationException($"Attempting to create EnvDTE AST node for unknown type ID: {model.TypeId}")
		};
	}
}
