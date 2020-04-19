using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Common;
using JetBrains.EnvDTE.Client.Impl.ProjectModel;

namespace JetBrains.EnvDTE.Client.Impl.Model
{
    public sealed class FileCodeModelImpl : FileCodeModel2
    {
        [NotNull]
        private DteImplementation DteImplementation { get; }

        private ProjectItemImplementation MyParent { get; }

        public FileCodeModelImpl(
            [NotNull] DteImplementation dteImplementation,
            [NotNull] ProjectItemImplementation parent
        )
        {
            DteImplementation = dteImplementation;
            MyParent = parent;
        }

        [NotNull]
        public DTE DTE => DteImplementation;

        [NotNull]
        public ProjectItem Parent => MyParent;

        [CanBeNull]
        public string Language => DteImplementation
            .DteProtocolModel
            .ProjectItem_get_Language
            .Sync(MyParent.ProjectItemModel).ToEnvDTELanguage();

        [NotNull]
        public CodeElements CodeElements => new CodeElementsImplementation(
            new EnvDTEElementRegistrar(DteImplementation),
            DteImplementation
                .DteProtocolModel
                .FileCodeModel_get_CodeElements
                .Sync(MyParent.ProjectItemModel),
            this
        );

        public vsCMParseStatus ParseStatus => throw new NotImplementedException();
        public bool IsBatchOpen => throw new NotImplementedException();

        CodeElement FileCodeModel.CodeElementFromPoint(TextPoint Point, vsCMElement Scope) =>
            throw new NotImplementedException();

        CodeNamespace FileCodeModel2.AddNamespace(string Name, object Position) =>
            throw new NotImplementedException();

        CodeClass FileCodeModel2.AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeInterface FileCodeModel2.AddInterface(string Name, object Position, object Bases,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeFunction FileCodeModel2.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeVariable FileCodeModel2.AddVariable(string Name, object Type, object Position, vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeAttribute FileCodeModel2.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        CodeStruct FileCodeModel2.AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeEnum FileCodeModel2.AddEnum(string Name, object Position, object Bases, vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeDelegate FileCodeModel2.AddDelegate(string Name, object Type, object Position, vsCMAccess Access) =>
            throw new NotImplementedException();

        void FileCodeModel2.Remove(object Element)
        {
            throw new NotImplementedException();
        }

        public void Synchronize()
        {
            throw new NotImplementedException();
        }

        public CodeImport AddImport(string Name, object Position, string Alias = "") =>
            throw new NotImplementedException();

        public void BeginBatch()
        {
            throw new NotImplementedException();
        }

        public void EndBatch()
        {
            throw new NotImplementedException();
        }

        public CodeElement ElementFromID(string ID) => throw new NotImplementedException();

        CodeElement FileCodeModel2.CodeElementFromPoint(TextPoint Point, vsCMElement Scope) =>
            throw new NotImplementedException();

        CodeNamespace FileCodeModel.AddNamespace(string Name, object Position) =>
            throw new NotImplementedException();

        CodeClass FileCodeModel.AddClass(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeInterface FileCodeModel.AddInterface(string Name, object Position, object Bases,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeFunction FileCodeModel.AddFunction(string Name, vsCMFunction Kind, object Type, object Position,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeVariable FileCodeModel.AddVariable(string Name, object Type, object Position,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeAttribute FileCodeModel.AddAttribute(string Name, string Value, object Position) =>
            throw new NotImplementedException();

        CodeStruct FileCodeModel.AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeEnum FileCodeModel.AddEnum(string Name, object Position, object Bases, vsCMAccess Access) =>
            throw new NotImplementedException();

        CodeDelegate FileCodeModel.AddDelegate(string Name, object Type, object Position,
            vsCMAccess Access) =>
            throw new NotImplementedException();

        void FileCodeModel.Remove(object Element)
        {
            throw new NotImplementedException();
        }
    }
}
