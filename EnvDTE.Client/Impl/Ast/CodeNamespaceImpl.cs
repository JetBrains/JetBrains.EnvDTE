using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public sealed class CodeNamespaceImpl : CodeElementBase, CodeNamespace, CodeElement2
    {
        public CodeNamespaceImpl([NotNull] DteImplementation implementation, [NotNull] CodeElementModel model) : base(implementation, model)
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
        public CodeElements Members => throw new NotImplementedException();

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

        public object get_Extender(string ExtenderName) => throw new NotImplementedException();

        public TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes) =>
            throw new NotImplementedException();

        public TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes) =>
            throw new NotImplementedException();

        public void RenameSymbol(string NewName)
        {
            throw new NotImplementedException();
        }

        public CodeNamespace AddNamespace(string Name, object Position) => throw new NotImplementedException();

        public CodeClass AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        public CodeInterface AddInterface(string Name, object Position, object Bases,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        public CodeStruct AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault) =>
            throw new NotImplementedException();

        public CodeEnum AddEnum(string Name, object Position, object Bases,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault) => throw new NotImplementedException();

        public CodeDelegate AddDelegate(string Name, object Type, object Position,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault) => throw new NotImplementedException();

        public void Remove(object Element)
        {
            throw new NotImplementedException();
        }
    }
}
