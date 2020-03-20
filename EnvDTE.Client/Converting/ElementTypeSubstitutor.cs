using System;
using System.Collections.Generic;
using JetBrains.EnvDTE.Client.Impl.Ast;
using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace JetBrains.EnvDTE.Client.Converting
{
    public sealed class ElementTypeSubstitutor
    {
        public static Type GetEnvDTEType(int id) => Dictionary[id].EnvDTEType;
        public static Type GetPsiType(int id) => Dictionary[id].PsiType;
        public static int GetIdByEnvDTEType(Type envDTEType) => throw new NotImplementedException();
        public static int GetIdByPsiType(Type psiType) => throw new NotImplementedException();

        static ElementTypeSubstitutor()
        {
            Register<CodeNamespaceImpl, ICSharpNamespaceDeclaration>();

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
}
