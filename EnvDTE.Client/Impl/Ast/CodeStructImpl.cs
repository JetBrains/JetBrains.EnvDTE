using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public sealed class CodeStructImpl : CodeElementBase, CodeElement2, CodeStruct2
    {
        public CodeStructImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        ) : base(implementation, model, parent)
        {
        }

        public vsCMElement Kind => vsCMElement.vsCMElementStruct;
        public bool IsCodeType => true;

        public string FullName => throw new NotImplementedException();
        public vsCMInfoLocation InfoLocation => throw new NotImplementedException();
        public string Language => throw new NotImplementedException();
        public TextPoint StartPoint => throw new NotImplementedException();
        public TextPoint EndPoint => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public string ElementID => throw new NotImplementedException();
        public CodeNamespace Namespace => throw new NotImplementedException();
        public CodeElements Bases => throw new NotImplementedException();

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

        public bool IsAbstract
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public vsCMDataTypeKind DataTypeKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public CodeElements Members => throw new NotImplementedException();
        public CodeElements Attributes => throw new NotImplementedException();
        public CodeElements DerivedTypes => throw new NotImplementedException();
        public CodeElements ImplementedInterfaces => throw new NotImplementedException();
        public bool IsGeneric => throw new NotImplementedException();
        public CodeElements Parts => throw new NotImplementedException();
        object CodeStruct.get_Extender(string ExtenderName) => throw new NotImplementedException();
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
        TextPoint CodeStruct2.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeStruct2.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        CodeElement CodeStruct2.AddBase(object Base, object Position) => throw new NotImplementedException();

        CodeAttribute CodeStruct2.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        void CodeStruct2.RemoveBase(object Element)
        {
            throw new NotImplementedException();
        }

        void CodeStruct2.RemoveMember(object Element)
        {
            throw new NotImplementedException();
        }

        bool CodeStruct2.get_IsDerivedFrom(string FullName) => throw new NotImplementedException();

        CodeInterface CodeStruct2.AddImplementedInterface(object Base, object Position) =>
            throw new NotImplementedException();

        CodeFunction CodeStruct2.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new NotImplementedException();

        CodeVariable CodeStruct2.AddVariable(string Name, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new NotImplementedException();

        CodeProperty CodeStruct2.AddProperty(string GetterName, string PutterName, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new NotImplementedException();

        CodeClass CodeStruct2.AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeStruct CodeStruct2.AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeEnum CodeStruct2.AddEnum(string Name, object Position, object Bases,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeDelegate CodeStruct2.AddDelegate(string Name, object Type, object Position,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        void CodeStruct2.RemoveInterface(object Element)
        {
            throw new NotImplementedException();
        }

        public CodeEvent AddEvent(string Name, string FullDelegateName, bool CreatePropertyStyleEvent = false,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        object CodeStruct2.get_Extender(string ExtenderName) => throw new NotImplementedException();
        TextPoint CodeStruct.GetStartPoint(vsCMPart Part) => throw new NotImplementedException();
        TextPoint CodeStruct.GetEndPoint(vsCMPart Part) => throw new NotImplementedException();
        CodeElement CodeStruct.AddBase(object Base, object Position) => throw new NotImplementedException();

        CodeAttribute CodeStruct.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        void CodeStruct.RemoveBase(object Element)
        {
            throw new NotImplementedException();
        }

        void CodeStruct.RemoveMember(object Element)
        {
            throw new NotImplementedException();
        }

        bool CodeStruct.get_IsDerivedFrom(string FullName) => throw new NotImplementedException();

        CodeInterface CodeStruct.AddImplementedInterface(object Base, object Position) =>
            throw new NotImplementedException();

        CodeFunction CodeStruct.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new NotImplementedException();

        CodeVariable CodeStruct.AddVariable(string Name, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new NotImplementedException();

        CodeProperty CodeStruct.AddProperty(string GetterName, string PutterName, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new NotImplementedException();

        CodeClass CodeStruct.AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeStruct CodeStruct.AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeEnum CodeStruct.AddEnum(string Name, object Position, object Bases,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeDelegate CodeStruct.AddDelegate(string Name, object Type, object Position,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        void CodeStruct.RemoveInterface(object Element)
        {
            throw new NotImplementedException();
        }
    }
}
