using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Model
{
    public sealed class FileCodeModelImpl : FileCodeModel2
    {
        [NotNull]
        private DteImplementation DteImplementation { get; }

        public FileCodeModelImpl([NotNull] DteImplementation dteImplementation, [NotNull] ProjectItem parent)
        {
            DteImplementation = dteImplementation;
            Parent = parent;
        }

        [NotNull]
        public DTE DTE => DteImplementation;

        [NotNull]
        public ProjectItem Parent { get; }

        public string Language => throw new System.NotImplementedException();
        public CodeElements CodeElements => throw new System.NotImplementedException();
        public vsCMParseStatus ParseStatus => throw new System.NotImplementedException();
        public bool IsBatchOpen => throw new System.NotImplementedException();

        CodeElement FileCodeModel.CodeElementFromPoint(TextPoint Point, vsCMElement Scope) =>
            throw new System.NotImplementedException();

        CodeNamespace FileCodeModel2.AddNamespace(string Name, object Position) =>
            throw new System.NotImplementedException();

        CodeClass FileCodeModel2.AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeInterface FileCodeModel2.AddInterface(string Name, object Position, object Bases,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeFunction FileCodeModel2.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeVariable FileCodeModel2.AddVariable(string Name, object Type, object Position, vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeAttribute FileCodeModel2.AddAttribute(string Name, string Value, object Position) =>
            throw new System.NotImplementedException();

        CodeStruct FileCodeModel2.AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeEnum FileCodeModel2.AddEnum(string Name, object Position, object Bases, vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeDelegate FileCodeModel2.AddDelegate(string Name, object Type, object Position, vsCMAccess Access) =>
            throw new System.NotImplementedException();

        void FileCodeModel2.Remove(object Element)
        {
            throw new System.NotImplementedException();
        }

        public void Synchronize()
        {
            throw new System.NotImplementedException();
        }

        public CodeImport AddImport(string Name, object Position, string Alias = "") =>
            throw new System.NotImplementedException();

        public void BeginBatch()
        {
            throw new System.NotImplementedException();
        }

        public void EndBatch()
        {
            throw new System.NotImplementedException();
        }

        public CodeElement ElementFromID(string ID) => throw new System.NotImplementedException();

        CodeElement FileCodeModel2.CodeElementFromPoint(TextPoint Point, vsCMElement Scope) =>
            throw new System.NotImplementedException();

        CodeNamespace FileCodeModel.AddNamespace(string Name, object Position) =>
            throw new System.NotImplementedException();

        CodeClass FileCodeModel.AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeInterface FileCodeModel.AddInterface(string Name, object Position, object Bases,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeFunction FileCodeModel.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeVariable FileCodeModel.AddVariable(string Name, object Type, object Position,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeAttribute FileCodeModel.AddAttribute(string Name, string Value, object Position) =>
            throw new System.NotImplementedException();

        CodeStruct FileCodeModel.AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeEnum FileCodeModel.AddEnum(string Name, object Position, object Bases, vsCMAccess Access) =>
            throw new System.NotImplementedException();

        CodeDelegate FileCodeModel.AddDelegate(string Name, object Type, object Position,
            vsCMAccess Access) =>
            throw new System.NotImplementedException();

        void FileCodeModel.Remove(object Element)
        {
            throw new System.NotImplementedException();
        }
    }
}
