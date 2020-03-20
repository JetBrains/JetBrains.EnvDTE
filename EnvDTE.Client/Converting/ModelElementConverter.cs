using System;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl;
using JetBrains.EnvDTE.Client.Impl.Ast;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Converting
{
    // TODO: share this between client and host?
    public sealed class ModelElementConverter
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        public ModelElementConverter([NotNull] DteImplementation implementation) => Implementation = implementation;

        [NotNull]
        public CodeElement Convert([NotNull] CodeElementModel model) => model switch
        {
            MethodModel methodModel => ConvertFunction(methodModel),
            NamespaceModel namespaceModel => ConvertNamespace(namespaceModel),
            TypeModel typeModel => ConvertType(typeModel),
            _ => throw new ArgumentOutOfRangeException(nameof(model))
        };

        [NotNull]
        public CodeElement ConvertFunction([NotNull] MethodModel model) => new CodeFunctionImpl(Implementation, model);

        [NotNull]
        public CodeElement ConvertType([NotNull] TypeModel model) => model.Kind switch
        {
            TypeKind.Interface => new CodeInterfaceImpl(Implementation, model),
            TypeKind.Class => new CodeClassImpl(Implementation, model),
            TypeKind.Struct => new CodeStructImpl(Implementation, model),
            _ => throw new NotImplementedException()
        };

        [NotNull]
        public CodeElement ConvertNamespace([NotNull] NamespaceModel model) =>
            new CodeNamespaceImpl(Implementation, model);
    }
}
