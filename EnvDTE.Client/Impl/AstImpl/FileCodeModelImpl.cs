using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModelImpl;
using JetBrains.EnvDTE.Client.Util;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
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
            .Sync(new(MyParent.ProjectItemModel)).FromRdLanguageModel();

        [NotNull]
        public CodeElements CodeElements => new CodeElementsImplementation(
            new EnvDTEElementRegistrar(DteImplementation),
            DteImplementation
                .DteProtocolModel
                .FileCodeModel_get_CodeElements
                .Sync(new(MyParent.ProjectItemModel)),
            this
        );

        public vsCMParseStatus ParseStatus => throw new NotImplementedException();
        public bool IsBatchOpen => throw new NotImplementedException();

        CodeElement FileCodeModel.CodeElementFromPoint(TextPoint point, vsCMElement scope) =>
            throw new NotImplementedException();

        CodeNamespace FileCodeModel2.AddNamespace(string name, object position) =>
            throw new NotImplementedException();

        CodeClass FileCodeModel2.AddClass(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeInterface FileCodeModel2.AddInterface(string name, object position, object bases,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeFunction FileCodeModel2.AddFunction(string name, vsCMFunction kind, object type, object position,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeVariable FileCodeModel2.AddVariable(string name, object type, object position, vsCMAccess access) =>
            throw new NotImplementedException();

        CodeAttribute FileCodeModel2.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        CodeStruct FileCodeModel2.AddStruct(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeEnum FileCodeModel2.AddEnum(string name, object position, object bases, vsCMAccess access) =>
            throw new NotImplementedException();

        CodeDelegate FileCodeModel2.AddDelegate(string name, object type, object position, vsCMAccess access) =>
            throw new NotImplementedException();

        void FileCodeModel2.Remove(object element)
        {
            throw new NotImplementedException();
        }

        public void Synchronize()
        {
            throw new NotImplementedException();
        }

        public CodeImport AddImport(string name, object position, string alias = "") =>
            throw new NotImplementedException();

        public void BeginBatch()
        {
            throw new NotImplementedException();
        }

        public void EndBatch()
        {
            throw new NotImplementedException();
        }

        public CodeElement ElementFromID(string id) => throw new NotImplementedException();

        CodeElement FileCodeModel2.CodeElementFromPoint(TextPoint point, vsCMElement scope) =>
            throw new NotImplementedException();

        CodeNamespace FileCodeModel.AddNamespace(string name, object position) =>
            throw new NotImplementedException();

        CodeClass FileCodeModel.AddClass(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeInterface FileCodeModel.AddInterface(string name, object position, object bases,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeFunction FileCodeModel.AddFunction(string name, vsCMFunction kind, object type, object position,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeVariable FileCodeModel.AddVariable(string name, object type, object position,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeAttribute FileCodeModel.AddAttribute(string name, string value, object position) =>
            throw new NotImplementedException();

        CodeStruct FileCodeModel.AddStruct(string name, object position, object bases, object implementedInterfaces,
            vsCMAccess access) =>
            throw new NotImplementedException();

        CodeEnum FileCodeModel.AddEnum(string name, object position, object bases, vsCMAccess access) =>
            throw new NotImplementedException();

        CodeDelegate FileCodeModel.AddDelegate(string name, object type, object position,
            vsCMAccess access) =>
            throw new NotImplementedException();

        void FileCodeModel.Remove(object element)
        {
            throw new NotImplementedException();
        }
    }
}
