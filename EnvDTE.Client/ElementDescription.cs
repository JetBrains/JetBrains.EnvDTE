using System;

namespace JetBrains.EnvDTE.Client
{
    public sealed class ElementDescription
    {
        public int Id { get; }
        public Type EnvDTEType { get; }
        public Type PsiType { get; }

        public ElementDescription(int id, Type envDTEType, Type psiType)
        {
            Id = id;
            EnvDTEType = envDTEType;
            PsiType = psiType;
        }

        public override int GetHashCode() => Id;
    }
}
