using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
{
    public sealed class CodeAttributeImpl : CodeElementBase, CodeAttribute2, CodeElement2
    {
        public CodeAttributeImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        ) : base(implementation, model, parent)
        {
        }

        public vsCMElement Kind => vsCMElement.vsCMElementAttribute;
        public bool IsCodeType => false;

        public vsCMInfoLocation InfoLocation => throw new NotImplementedException();
        public TextPoint StartPoint => throw new NotImplementedException();
        public TextPoint EndPoint => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public string ElementID => throw new NotImplementedException();

        [NotNull]
        public string Value
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Target
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public CodeElements Arguments => throw new NotImplementedException();
        object CodeAttribute.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeElement2.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeElement2.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        public void RenameSymbol(string NewName) => throw new NotImplementedException();
        object CodeElement2.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeElement.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeElement.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        object CodeElement.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeAttribute2.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeAttribute2.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        void CodeAttribute2.Delete() => throw new NotImplementedException();

        public CodeAttributeArgument AddArgument(string Value, object Name, object Position) =>
            throw new NotImplementedException();

        object CodeAttribute2.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeAttribute.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeAttribute.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        void CodeAttribute.Delete() => throw new NotImplementedException();
    }
}
