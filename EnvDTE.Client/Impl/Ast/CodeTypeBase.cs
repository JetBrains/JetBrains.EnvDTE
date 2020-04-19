using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Model;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public abstract class CodeTypeBase : CodeElementBase
    {
        protected CodeTypeBase(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        ) : base(implementation, model, parent)
        {
        }

        public bool IsCodeType => true;

        [NotNull]
        public CodeElements Bases => new CodeElementsImplementation(
            EnvDTEElementRegistrar,
            Implementation.DteProtocolModel.CodeElement_get_Bases.Sync(Model),
            this
        );

        [NotNull]
        public CodeNamespace Namespace => (CodeNamespace) EnvDTEElementRegistrar.Convert(
            Implementation.DteProtocolModel.CodeElement_get_Namespace.Sync(Model),
            null
        );
    }
}
