using System;
using EnvDTE;
using EnvDTE80;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
{
    public sealed class CodeTypeRefImpl : CodeTypeRef2
    {
        [NotNull] public CodeType CodeType { get; set; }

        [NotNull] public object Parent { get; }

        public CodeTypeRefImpl([NotNull] CodeType codeType, [NotNull] object parent)
        {
            CodeType = codeType;
            Parent = parent;
        }

        public DTE DTE => CodeType.DTE;
        public vsCMTypeRef TypeKind => throw new NotImplementedException();

        public CodeTypeRef ElementType
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string AsString => throw new NotImplementedException();
        public string AsFullName => throw new NotImplementedException();

        public int Rank
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public bool IsGeneric => throw new NotImplementedException();

        CodeTypeRef CodeTypeRef2.CreateArrayType(int Rank) => throw new NotImplementedException();

        CodeTypeRef CodeTypeRef.CreateArrayType(int Rank) => throw new NotImplementedException();
    }
}
