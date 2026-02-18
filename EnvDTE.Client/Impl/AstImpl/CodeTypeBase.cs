using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
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
        public object get_Extender(string extenderName) => throw new System.NotImplementedException();

        public TextPoint GetStartPoint(vsCMPart part = vsCMPart.vsCMPartWholeWithAttributes) =>
            throw new System.NotImplementedException();

        public TextPoint GetEndPoint(vsCMPart part = vsCMPart.vsCMPartWholeWithAttributes) =>
            throw new System.NotImplementedException();

        public CodeElement AddBase(object @base, object position) => throw new System.NotImplementedException();

        public CodeAttribute AddAttribute(string name, string value, object position) =>
            throw new System.NotImplementedException();

        public void RemoveBase(object element)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMember(object element)
        {
            throw new System.NotImplementedException();
        }

        public bool get_IsDerivedFrom(string fullName) => throw new System.NotImplementedException();

        [NotNull]
        public CodeNamespace Namespace => (CodeNamespace) EnvDTEElementRegistrar.Convert(
            Implementation.DteProtocolModel.CodeElement_get_Namespace.Sync(Model),
            null
        );
    }
}
