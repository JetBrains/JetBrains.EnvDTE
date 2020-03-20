using System;
using System.Collections.Generic;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public sealed class CodeFunctionImpl : CodeElementBase<MethodModel>, CodeElement2, CodeFunction2
    {
        public CodeFunctionImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] MethodModel model
        ) : base(implementation, model)
        {
        }

        public CodeElements Collection => throw new NotImplementedException();
        public string FullName => throw new NotImplementedException();
        public ProjectItem ProjectItem => throw new NotImplementedException();
        public vsCMElement Kind => throw new NotImplementedException();
        public bool IsCodeType => throw new NotImplementedException();
        public vsCMInfoLocation InfoLocation => throw new NotImplementedException();
        public CodeElements Children => throw new NotImplementedException();
        public string Language => throw new NotImplementedException();
        public TextPoint StartPoint => throw new NotImplementedException();
        public TextPoint EndPoint => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public string ElementID => throw new NotImplementedException();
        public object Parent => throw new NotImplementedException();
        public vsCMFunction FunctionKind => throw new NotImplementedException();
        public CodeElements Parameters => throw new NotImplementedException();
        public bool IsOverloaded => throw new NotImplementedException();

        public CodeTypeRef Type
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public vsCMAccess Access
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

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
        public CodeElements Attributes => throw new NotImplementedException();

        public bool CanOverride
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public vsCMOverrideKind OverrideKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool IsGeneric => throw new NotImplementedException();
        object CodeFunction.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeElement2.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeElement2.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();

        public void RenameSymbol(string NewName)
        {
            throw new NotImplementedException();
        }

        object CodeElement2.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeElement.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeElement.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        object CodeElement.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeFunction2.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeFunction2.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        string CodeFunction2.get_Prototype(int Flags) => throw new NotImplementedException();

        CodeParameter CodeFunction2.AddParameter(string Name, object Type, object Position) =>
            throw new NotImplementedException();

        CodeAttribute CodeFunction2.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        void CodeFunction2.RemoveParameter(object Element) => throw new NotImplementedException();
        object CodeFunction2.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeFunction.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeFunction.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        string CodeFunction.get_Prototype(int Flags) => throw new NotImplementedException();

        CodeParameter CodeFunction.AddParameter(string Name, object Type, object Position) =>
            throw new NotImplementedException();

        CodeAttribute CodeFunction.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        void CodeFunction.RemoveParameter(object Element) => throw new NotImplementedException();

        protected override IReadOnlyList<CodeElementModel> GetChildren(MethodModel model) =>
            throw new NotImplementedException();
    }
}
