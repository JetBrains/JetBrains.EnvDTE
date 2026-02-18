using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
{
    public sealed class CodeInterfaceImpl : CodeTypeBase, CodeElement2, CodeInterface2
    {
        public CodeInterfaceImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        ) : base(implementation, model, parent)
        {
        }

        public override vsCMElement Kind => vsCMElement.vsCMElementInterface;

        public string ElementID => throw new NotImplementedException();
        public bool IsGeneric => throw new NotImplementedException();
        public CodeElements Parts => throw new NotImplementedException();

        public vsCMDataTypeKind DataTypeKind
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        object CodeInterface.get_Extender(string extenderName) => throw new NotImplementedException();
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
        TextPoint CodeInterface2.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeInterface2.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        CodeElement CodeInterface2.AddBase(object @base, object position) => throw new NotImplementedException();

        CodeAttribute CodeInterface2.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        void CodeInterface2.RemoveBase(object element)
        {
            throw new NotImplementedException();
        }

        void CodeInterface2.RemoveMember(object element)
        {
            throw new NotImplementedException();
        }

        bool CodeInterface2.get_IsDerivedFrom(string fullName) => throw new NotImplementedException();

        CodeFunction CodeInterface2.AddFunction(string name, vsCMFunction kind, object type, object position,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeProperty CodeInterface2.AddProperty(string getterName, string putterName, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();

        public CodeEvent AddEvent(string name, string fullDelegateName, bool createPropertyStyleEvent = false,
            object position = null,
            vsCMAccess access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        object CodeInterface2.get_Extender(string extenderName) => throw new NotImplementedException();
        TextPoint CodeInterface.GetStartPoint(vsCMPart part) => throw new NotImplementedException();
        TextPoint CodeInterface.GetEndPoint(vsCMPart part) => throw new NotImplementedException();
        CodeElement CodeInterface.AddBase(object @base, object position) => throw new NotImplementedException();

        CodeAttribute CodeInterface.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        void CodeInterface.RemoveBase(object element)
        {
            throw new NotImplementedException();
        }

        void CodeInterface.RemoveMember(object element)
        {
            throw new NotImplementedException();
        }

        bool CodeInterface.get_IsDerivedFrom(string fullName) => throw new NotImplementedException();

        CodeFunction CodeInterface.AddFunction(string name, vsCMFunction kind, object type, object position,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeProperty CodeInterface.AddProperty(string getterName, string putterName, object type, object position,
            vsCMAccess access, object location) =>
            throw new NotImplementedException();
    }
}
