using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public abstract class CodeTypeBase : CodeElementBase, CodeType
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

        public abstract vsCMElement Kind { get; }

        public vsCMInfoLocation InfoLocation => throw new System.NotImplementedException();
        public TextPoint StartPoint => throw new System.NotImplementedException();
        public TextPoint EndPoint => throw new System.NotImplementedException();
        public object ExtenderNames => throw new System.NotImplementedException();
        public string ExtenderCATID => throw new System.NotImplementedException();

        public string DocComment
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public string Comment
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public CodeElements DerivedTypes => throw new System.NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new System.NotImplementedException();

        public TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes) =>
            throw new System.NotImplementedException();

        public TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes) =>
            throw new System.NotImplementedException();

        public CodeElement AddBase(object Base, object Position) => throw new System.NotImplementedException();

        public CodeAttribute AddAttribute(string Name, string Value, object Position) =>
            throw new System.NotImplementedException();

        public void RemoveBase(object Element)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMember(object Element)
        {
            throw new System.NotImplementedException();
        }

        public bool get_IsDerivedFrom(string FullName) => throw new System.NotImplementedException();

        [NotNull]
        public CodeNamespace Namespace => (CodeNamespace) EnvDTEElementRegistrar.Convert(
            Implementation.DteProtocolModel.CodeElement_get_Namespace.Sync(Model),
            null
        );
    }
}
