using System;
using EnvDTE;
using EnvDTE80;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public sealed class CodeNamespaceImpl : CodeNamespace, CodeElement2
    {
        public DTE DTE { get; }
        public CodeElements Collection { get; }
        public string Name { get; set; }
        public string FullName { get; }
        public ProjectItem ProjectItem { get; }
        public vsCMElement Kind { get; }
        public bool IsCodeType { get; }
        public vsCMInfoLocation InfoLocation { get; }
        public CodeElements Children { get; }
        public string Language { get; }
        public TextPoint StartPoint { get; }
        public TextPoint EndPoint { get; }
        public object ExtenderNames { get; }
        public string ExtenderCATID { get; }
        public string ElementID { get; }
        public object Parent { get; }
        public CodeElements Members { get; }
        public string DocComment { get; set; }
        public string Comment { get; set; }
        public object get_Extender(string ExtenderName) => throw new NotImplementedException();

        public TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes) => throw new NotImplementedException();

        public TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes) => throw new NotImplementedException();
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

        public CodeEnum AddEnum(string Name, object Position, object Bases, vsCMAccess Access = vsCMAccess.vsCMAccessDefault) => throw new NotImplementedException();

        public CodeDelegate AddDelegate(string Name, object Type, object Position, vsCMAccess Access = vsCMAccess.vsCMAccessDefault) => throw new NotImplementedException();

        public void Remove(object Element)
        {
            throw new NotImplementedException();
        }
    }
}
