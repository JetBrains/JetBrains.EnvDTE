using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
{
    public sealed class CodeStructImpl : CodeTypeBase, CodeElement2, CodeStruct2
    {
        public CodeStructImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        ) : base(implementation, model, parent)
        {
        }

        public override vsCMElement Kind => vsCMElement.vsCMElementStruct;

        public string ElementID => throw new NotImplementedException();
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

        public CodeElements ImplementedInterfaces => throw new NotImplementedException();
        public bool IsGeneric => throw new NotImplementedException();
        public CodeElements Parts => throw new NotImplementedException();
        object CodeStruct.get_Extender(string extenderName) => throw new NotImplementedException();
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
        TextPoint CodeStruct2.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeStruct2.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        CodeElement CodeStruct2.AddBase(object @base, object position) => throw new NotImplementedException();

        CodeAttribute CodeStruct2.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        void CodeStruct2.RemoveBase(object element)
        {
            throw new NotImplementedException();
        }

        void CodeStruct2.RemoveMember(object element)
        {
            throw new NotImplementedException();
        }

        bool CodeStruct2.get_IsDerivedFrom(string fullName) => throw new NotImplementedException();

        CodeInterface CodeStruct2.AddImplementedInterface(object @base, object position) =>
            throw new NotImplementedException();

        CodeFunction CodeStruct2.AddFunction(string name, vsCMFunction kind, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeVariable CodeStruct2.AddVariable(string name, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeProperty CodeStruct2.AddProperty(string getterName, string putterName, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeClass CodeStruct2.AddClass(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeStruct CodeStruct2.AddStruct(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeEnum CodeStruct2.AddEnum(string name, object position, object bases,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeDelegate CodeStruct2.AddDelegate(string name, object type, object position,
            vsCMAccess access) =>
            throw new NotImplementedException();

        void CodeStruct2.RemoveInterface(object element)
        {
            throw new NotImplementedException();
        }

        public CodeEvent AddEvent(string name, string fullDelegateName, bool createPropertyStyleEvent = false,
            object position = null,
            vsCMAccess access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        object CodeStruct2.get_Extender(string extenderName) => throw new NotImplementedException();
        TextPoint CodeStruct.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeStruct.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        CodeElement CodeStruct.AddBase(object @base, object position) => throw new NotImplementedException();

        CodeAttribute CodeStruct.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        void CodeStruct.RemoveBase(object element)
        {
            throw new NotImplementedException();
        }

        void CodeStruct.RemoveMember(object element)
        {
            throw new NotImplementedException();
        }

        bool CodeStruct.get_IsDerivedFrom(string fullName) => throw new NotImplementedException();

        CodeInterface CodeStruct.AddImplementedInterface(object @base, object position) =>
            throw new NotImplementedException();

        CodeFunction CodeStruct.AddFunction(string name, vsCMFunction kind, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeVariable CodeStruct.AddVariable(string name, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeProperty CodeStruct.AddProperty(string getterName, string putterName, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeClass CodeStruct.AddClass(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeStruct CodeStruct.AddStruct(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeEnum CodeStruct.AddEnum(string name, object position, object bases,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeDelegate CodeStruct.AddDelegate(string name, object type, object position,
            vsCMAccess access) =>
            throw new NotImplementedException();

        void CodeStruct.RemoveInterface(object element) => throw new NotImplementedException();
    }
}
