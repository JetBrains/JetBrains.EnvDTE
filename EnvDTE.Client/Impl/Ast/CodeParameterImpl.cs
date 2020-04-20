using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public sealed class CodeParameterImpl : CodeElementBase, CodeParameter2, CodeElement
    {
        public CodeParameterImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        ) : base(implementation, model, parent)
        {
        }

        [NotNull]
        public new CodeElement Parent => (CodeElement) base.Parent ?? throw new InvalidOperationException();

        public vsCMElement Kind => vsCMElement.vsCMElementParameter;
        public bool IsCodeType => false;

        [NotNull]
        public CodeTypeRef Type
        {
            get => new CodeTypeRefImpl(
                (CodeType) EnvDTEElementRegistrar.Convert(
                    Implementation.DteProtocolModel.CodeParameter_get_Type.Sync(Model),
                    null
                ),
                this
            );
            set => throw new NotImplementedException();
        }

        #region NotImplemented
        public vsCMInfoLocation InfoLocation => throw new NotImplementedException();
        public TextPoint StartPoint => throw new NotImplementedException();
        public TextPoint EndPoint => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public CodeElements Attributes => throw new NotImplementedException();

        public string DocComment
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public vsCMParameterKind ParameterKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string DefaultValue
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        object CodeParameter.get_Extender(string ExtenderName) => throw new NotImplementedException();
        public TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes) => throw new NotImplementedException();

        public TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes) => throw new NotImplementedException();
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeParameter2.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeParameter2.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();

        CodeAttribute CodeParameter2.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        object CodeParameter2.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeParameter.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeParameter.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();

        CodeAttribute CodeParameter.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();
        #endregion
    }
}
