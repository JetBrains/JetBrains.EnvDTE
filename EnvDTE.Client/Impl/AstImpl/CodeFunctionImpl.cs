using System;
using System.Linq;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
{
    public sealed class CodeFunctionImpl : CodeElementBase, CodeElement2, CodeFunction2
    {
        public CodeFunctionImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        ) : base(implementation, model, parent)
        {
        }

        public vsCMElement Kind => vsCMElement.vsCMElementFunction;
        public bool IsCodeType => false;

        [NotNull]
        public CodeElements Parameters => new CodeElementsOverList(
            Implementation,
            Children.OfType<CodeParameterImpl>().ToList(),
            this
        );

        public bool IsGeneric => throw new NotImplementedException();

        [NotNull]
        public CodeTypeRef Type
        {
            get => new CodeTypeRefImpl(
                (CodeType) EnvDTEElementRegistrar.Convert(
                    Implementation.DteProtocolModel.CodeFunction_get_Type.Sync(Model),
                    null
                ),
                this
            );
            set => throw new NotImplementedException();
        }

        public bool CanOverride
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public vsCMFunction FunctionKind => throw new NotImplementedException();

        #region NotImplemented
        public vsCMInfoLocation InfoLocation => throw new NotImplementedException();
        public TextPoint StartPoint => throw new NotImplementedException();
        public TextPoint EndPoint => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public string ElementID => throw new NotImplementedException();
        public bool IsOverloaded => throw new NotImplementedException();

        public bool IsShared
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool MustImplement
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string DocComment
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Comment
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public CodeElements Overloads => throw new NotImplementedException();

        public vsCMOverrideKind OverrideKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        object CodeFunction.get_Extender(string extenderName) => throw new NotImplementedException();
        TextPoint CodeElement2.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeElement2.GetEndPoint(vsCMPart part) => throw new NotImplementedException();

        public void RenameSymbol(string newName)
        {
            throw new NotImplementedException();
        }

        object CodeElement2.get_Extender(string extenderName) => throw new NotImplementedException();
        TextPoint CodeElement.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeElement.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        object CodeElement.get_Extender(string extenderName) => throw new NotImplementedException();
        TextPoint CodeFunction2.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeFunction2.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        string CodeFunction2.get_Prototype(int flags) => throw new NotImplementedException();

        CodeParameter CodeFunction2.AddParameter(string name, object type, object position) =>
            throw new NotImplementedException();

        CodeAttribute CodeFunction2.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        void CodeFunction2.RemoveParameter(object element) => throw new NotImplementedException();
        object CodeFunction2.get_Extender(string extenderName) => throw new NotImplementedException();
        TextPoint CodeFunction.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeFunction.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        string CodeFunction.get_Prototype(int flags) => throw new NotImplementedException();

        CodeParameter CodeFunction.AddParameter(string name, object type, object position) =>
            throw new NotImplementedException();

        CodeAttribute CodeFunction.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        void CodeFunction.RemoveParameter(object element) => throw new NotImplementedException();
        #endregion
    }
}
