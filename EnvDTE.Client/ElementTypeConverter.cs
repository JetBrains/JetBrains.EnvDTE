using System;
using System.Collections.Generic;
using JetBrains.EnvDTE.Client.Impl.Ast;
using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace JetBrains.EnvDTE.Client
{
    // TODO: share this between client and host?
    public static class ElementTypeConverter
    {
        public static Type GetEnvDTEType(int id) => Dictionary[id].EnvDTEType;
        public static Type GetPsiType(int id) => Dictionary[id].PsiType;
        public static int GetIdByEnvDTEType(Type envDTEType) => throw new NotImplementedException();
        public static int GetIdByPsiType(Type psiType) => throw new NotImplementedException();

        static ElementTypeConverter()
        {
            Register<CodeClassImpl, IClassDeclaration>();
            Register<CodeStructImpl, IStructDeclaration>();
            Register<CodeInterfaceImpl, IInterfaceDeclaration>();

            Register<CodeFunctionImpl, IMethodDeclaration>();
        }

        private static int CurrentId { get; set; }

        private static IDictionary<int, ElementDescription> Dictionary { get; } =
            new Dictionary<int, ElementDescription>();

        private static void Register<EnvDTEType, PsiType>()
        {
            Dictionary.Add(CurrentId, new ElementDescription(CurrentId, typeof(EnvDTEType), typeof(PsiType)));
            CurrentId += 1;
        }
    }

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
