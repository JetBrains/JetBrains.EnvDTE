using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public sealed class CodeInterfaceImpl : CodeElementBase, CodeElement2, CodeInterface2
    {
        public CodeInterfaceImpl([NotNull] DteImplementation implementation, [NotNull] CodeElementModel model) : base(implementation, model)
        {
        }

        public vsCMElement Kind => vsCMElement.vsCMElementInterface;
        public bool IsCodeType => true;

        public string FullName => throw new NotImplementedException();
        public vsCMInfoLocation InfoLocation => throw new NotImplementedException();
        public string Language => throw new NotImplementedException();
        public TextPoint StartPoint => throw new NotImplementedException();
        public TextPoint EndPoint => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public string ElementID => throw new NotImplementedException();
        public object Parent => throw new NotImplementedException();
        public CodeNamespace Namespace => throw new NotImplementedException();
        public CodeElements Bases => throw new NotImplementedException();
        public CodeElements Attributes => throw new NotImplementedException();
        public CodeElements DerivedTypes => throw new NotImplementedException();
        public bool IsGeneric => throw new NotImplementedException();
        public CodeElements Parts => throw new NotImplementedException();

        public vsCMAccess Access
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Comment
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string DocComment
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public vsCMDataTypeKind DataTypeKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        object CodeInterface.get_Extender(string ExtenderName) => throw new NotImplementedException();
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
        TextPoint CodeInterface2.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeInterface2.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        CodeElement CodeInterface2.AddBase(object Base, object Position) => throw new NotImplementedException();

        CodeAttribute CodeInterface2.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        void CodeInterface2.RemoveBase(object Element)
        {
            throw new NotImplementedException();
        }

        void CodeInterface2.RemoveMember(object Element)
        {
            throw new NotImplementedException();
        }

        bool CodeInterface2.get_IsDerivedFrom(string FullName) => throw new NotImplementedException();

        CodeFunction CodeInterface2.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeProperty CodeInterface2.AddProperty(string GetterName, string PutterName, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new NotImplementedException();

        public CodeEvent AddEvent(string Name, string FullDelegateName, bool CreatePropertyStyleEvent = false,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        object CodeInterface2.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeInterface.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeInterface.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        CodeElement CodeInterface.AddBase(object Base, object Position) => throw new NotImplementedException();

        CodeAttribute CodeInterface.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        void CodeInterface.RemoveBase(object Element)
        {
            throw new NotImplementedException();
        }

        void CodeInterface.RemoveMember(object Element)
        {
            throw new NotImplementedException();
        }

        bool CodeInterface.get_IsDerivedFrom(string FullName) => throw new NotImplementedException();

        CodeFunction CodeInterface.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeProperty CodeInterface.AddProperty(string GetterName, string PutterName, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new NotImplementedException();
    }
}
