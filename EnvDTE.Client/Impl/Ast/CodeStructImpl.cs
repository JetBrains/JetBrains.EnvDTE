using EnvDTE;
using EnvDTE80;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public sealed class CodeStructImpl : CodeStruct2
    {
        public DTE DTE => throw new System.NotImplementedException();
        public CodeElements Collection => throw new System.NotImplementedException();
        public string FullName => throw new System.NotImplementedException();
        public ProjectItem ProjectItem => throw new System.NotImplementedException();
        public vsCMElement Kind => throw new System.NotImplementedException();
        public bool IsCodeType => throw new System.NotImplementedException();
        public vsCMInfoLocation InfoLocation => throw new System.NotImplementedException();
        public CodeElements Children => throw new System.NotImplementedException();
        public string Language => throw new System.NotImplementedException();
        public TextPoint StartPoint => throw new System.NotImplementedException();
        public TextPoint EndPoint => throw new System.NotImplementedException();
        public object ExtenderNames => throw new System.NotImplementedException();
        public string ExtenderCATID => throw new System.NotImplementedException();
        public object Parent => throw new System.NotImplementedException();
        public CodeNamespace Namespace => throw new System.NotImplementedException();
        public CodeElements Bases => throw new System.NotImplementedException();

        public string Name
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public vsCMAccess Access
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public string DocComment
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public string Comment
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public bool IsAbstract
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public vsCMDataTypeKind DataTypeKind
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public CodeElements Members => throw new System.NotImplementedException();
        public CodeElements Attributes => throw new System.NotImplementedException();
        public CodeElements DerivedTypes => throw new System.NotImplementedException();
        public CodeElements ImplementedInterfaces => throw new System.NotImplementedException();
        public bool IsGeneric => throw new System.NotImplementedException();
        public CodeElements Parts => throw new System.NotImplementedException();
        object CodeStruct.get_Extender(string ExtenderName) => throw new System.NotImplementedException();
        TextPoint CodeStruct2.GetStartPoint(vsCMPart Part) => throw new System.NotImplementedException();
        TextPoint CodeStruct2.GetEndPoint(vsCMPart Part) => throw new System.NotImplementedException();
        CodeElement CodeStruct2.AddBase(object Base, object Position) => throw new System.NotImplementedException();

        CodeAttribute CodeStruct2.AddAttribute(string Name, string Value, object Position) =>
            throw new System.NotImplementedException();

        void CodeStruct2.RemoveBase(object Element)
        {
            throw new System.NotImplementedException();
        }

        void CodeStruct2.RemoveMember(object Element)
        {
            throw new System.NotImplementedException();
        }

        bool CodeStruct2.get_IsDerivedFrom(string FullName) => throw new System.NotImplementedException();

        CodeInterface CodeStruct2.AddImplementedInterface(object Base, object Position) =>
            throw new System.NotImplementedException();

        CodeFunction CodeStruct2.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new System.NotImplementedException();

        CodeVariable CodeStruct2.AddVariable(string Name, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new System.NotImplementedException();

        CodeProperty CodeStruct2.AddProperty(string GetterName, string PutterName, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new System.NotImplementedException();

        CodeClass CodeStruct2.AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeStruct CodeStruct2.AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeEnum CodeStruct2.AddEnum(string Name, object Position, object Bases,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeDelegate CodeStruct2.AddDelegate(string Name, object Type, object Position,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        void CodeStruct2.RemoveInterface(object Element)
        {
            throw new System.NotImplementedException();
        }

        public CodeEvent AddEvent(string Name, string FullDelegateName, bool CreatePropertyStyleEvent = false,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault) =>
            throw new System.NotImplementedException();

        object CodeStruct2.get_Extender(string ExtenderName) => throw new System.NotImplementedException();
        TextPoint CodeStruct.GetStartPoint(vsCMPart Part) => throw new System.NotImplementedException();
        TextPoint CodeStruct.GetEndPoint(vsCMPart Part) => throw new System.NotImplementedException();
        CodeElement CodeStruct.AddBase(object Base, object Position) => throw new System.NotImplementedException();

        CodeAttribute CodeStruct.AddAttribute(string Name, string Value, object Position) =>
            throw new System.NotImplementedException();

        void CodeStruct.RemoveBase(object Element)
        {
            throw new System.NotImplementedException();
        }

        void CodeStruct.RemoveMember(object Element)
        {
            throw new System.NotImplementedException();
        }

        bool CodeStruct.get_IsDerivedFrom(string FullName) => throw new System.NotImplementedException();

        CodeInterface CodeStruct.AddImplementedInterface(object Base, object Position) =>
            throw new System.NotImplementedException();

        CodeFunction CodeStruct.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new System.NotImplementedException();

        CodeVariable CodeStruct.AddVariable(string Name, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new System.NotImplementedException();

        CodeProperty CodeStruct.AddProperty(string GetterName, string PutterName, object Type, object Position,
            vsCMAccess Access, object Location) =>
            throw new System.NotImplementedException();

        CodeClass CodeStruct.AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeStruct CodeStruct.AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeEnum CodeStruct.AddEnum(string Name, object Position, object Bases,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeDelegate CodeStruct.AddDelegate(string Name, object Type, object Position,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        void CodeStruct.RemoveInterface(object Element)
        {
            throw new System.NotImplementedException();
        }
    }
}
