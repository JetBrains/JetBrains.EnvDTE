using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
{
    public sealed class CodeClassImpl : CodeTypeBase, CodeElement2, CodeClass2, CodeType
    {
        public CodeClassImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            object parent
        ) : base(implementation, model, parent)
        {
        }

        public override vsCMElement Kind => vsCMElement.vsCMElementClass;

        public string ElementID => throw new NotImplementedException();
        public CodeElements ImplementedInterfaces => throw new NotImplementedException();

        public bool IsAbstract
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public vsCMClassKind ClassKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public CodeElements PartialClasses => throw new NotImplementedException();

        public vsCMDataTypeKind DataTypeKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public CodeElements Parts => throw new NotImplementedException();

        public vsCMInheritanceKind InheritanceKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool IsGeneric => throw new NotImplementedException();

        public bool IsShared
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        object CodeClass.get_Extender(string extenderName) => throw new NotImplementedException();
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
        TextPoint CodeClass2.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeClass2.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        CodeElement CodeClass2.AddBase(object @base, object position) => throw new NotImplementedException();

        CodeAttribute CodeClass2.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        void CodeClass2.RemoveBase(object element) => throw new NotImplementedException();
        void CodeClass2.RemoveMember(object element) => throw new NotImplementedException();
        bool CodeClass2.get_IsDerivedFrom(string fullName) => throw new NotImplementedException();

        CodeInterface CodeClass2.AddImplementedInterface(object @base, object position) =>
            throw new NotImplementedException();

        CodeFunction CodeClass2.AddFunction(string name, vsCMFunction kind, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeVariable CodeClass2.AddVariable(string name, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeProperty CodeClass2.AddProperty(string getterName, string putterName, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeClass CodeClass2.AddClass(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeStruct CodeClass2.AddStruct(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeEnum CodeClass2.AddEnum(string name, object position, object bases, vsCMAccess access) =>
            throw new NotImplementedException();

        CodeDelegate CodeClass2.AddDelegate(string name, object type, object position, vsCMAccess access) =>
            throw new NotImplementedException();

        void CodeClass2.RemoveInterface(object element) => throw new NotImplementedException();

        public CodeEvent AddEvent(string name, string fullDelegateName, bool createPropertyStyleEvent = false,
            object location = null,
            vsCMAccess access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        object CodeClass2.get_Extender(string extenderName) => throw new NotImplementedException();
        TextPoint CodeClass.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeClass.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        CodeElement CodeClass.AddBase(object @base, object position) => throw new NotImplementedException();

        CodeAttribute CodeClass.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        void CodeClass.RemoveBase(object element) => throw new NotImplementedException();
        void CodeClass.RemoveMember(object element) => throw new NotImplementedException();
        bool CodeClass.get_IsDerivedFrom(string fullName) => throw new NotImplementedException();

        CodeInterface CodeClass.AddImplementedInterface(object @base, object position) =>
            throw new NotImplementedException();

        CodeFunction CodeClass.AddFunction(string name, vsCMFunction kind, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeVariable CodeClass.AddVariable(string name, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeProperty CodeClass.AddProperty(string getterName, string putterName, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        CodeClass CodeClass.AddClass(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeStruct CodeClass.AddStruct(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeEnum CodeClass.AddEnum(string name, object position, object bases, vsCMAccess access) =>
            throw new NotImplementedException();

        CodeDelegate CodeClass.AddDelegate(string name, object type, object position, vsCMAccess access) =>
            throw new NotImplementedException();

        void CodeClass.RemoveInterface(object element) => throw new NotImplementedException();
    }
}
