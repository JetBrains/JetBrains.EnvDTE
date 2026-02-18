using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
{
    public sealed class CodeNamespaceImpl : CodeElementBase, CodeNamespace, CodeElement2
    {
        public CodeNamespaceImpl(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        ) : base(implementation, model, parent)
        {
        }

        public vsCMElement Kind => vsCMElement.vsCMElementNamespace;
        public bool IsCodeType => false;

        public vsCMInfoLocation InfoLocation => throw new NotImplementedException();
        public TextPoint StartPoint => throw new NotImplementedException();
        public TextPoint EndPoint => throw new NotImplementedException();
        public object ExtenderNames => throw new NotImplementedException();
        public string ExtenderCATID => throw new NotImplementedException();
        public string ElementID => throw new NotImplementedException();

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

        public object get_Extender(string extenderName) => throw new NotImplementedException();

        public TextPoint GetStartPoint(vsCMPart part = vsCMPart.vsCMPartWholeWithAttributes) =>
            throw new NotImplementedException();

        public TextPoint GetEndPoint(vsCMPart part = vsCMPart.vsCMPartWholeWithAttributes) =>
            throw new NotImplementedException();

        public void RenameSymbol(string newName)
        {
            throw new NotImplementedException();
        }

        public CodeNamespace AddNamespace(string name, object position) => throw new NotImplementedException();

        public CodeClass AddClass(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        public CodeInterface AddInterface(string name, object position, object bases,
            vsCMAccess access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        public CodeStruct AddStruct(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        public CodeEnum AddEnum(string name, object position, object bases,
            vsCMAccess access = vsCMAccess.vsCMAccessDefault) => throw new NotImplementedException();

        public CodeDelegate AddDelegate(string name, object type, object position,
            vsCMAccess access = vsCMAccess.vsCMAccessDefault) => throw new NotImplementedException();

        public void Remove(object element)
        {
            throw new NotImplementedException();
        }
    }
}
