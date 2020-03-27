using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.EnvDTE.Host
{
    public static class PsiElementRegistrar
    {
        private static IList<(Type, int)> KnownTypes { get; } = new List<(Type, int)>();
        private static ISet<Type> TypesToReplaceWithChildren { get; } = new HashSet<Type>();

        /// <summary>
        /// The type id for TType will be set to id.
        /// The same id can later be used by the client
        /// to deduce the type of EnvDTE AST node to create.
        /// </summary>
        private static void RegisterType<TType>(int id) => KnownTypes.Add((typeof(TType), id));

        /// <summary>
        /// Elements that have not been registered are ignored by default.
        /// However, it is sometimes interesting to replace the entire element with its children.
        /// That is the case, for example, for namespaces and classes. The PSI structure of them is the following:
        /// INamespaceDeclaration("ConsoleApplication1")
        ///     INamespaceBody
        ///         IClassDeclaration("Class1")                    (?)
        ///         IClassDeclaration("Class2")
        /// The EnvDTE structure of them is the following:
        /// CodeNamespace("ConsoleApplication1")
        ///     CodeClass("Class1")
        ///     CodeClass("Class2")
        /// </summary>
        private static void ReplaceWithChildren<TType>() => TypesToReplaceWithChildren.Add(typeof(TType));

        static PsiElementRegistrar()
        {
            RegisterType<ICSharpNamespaceDeclaration>(1);
            RegisterType<IClassDeclaration>(2);
            RegisterType<IStructDeclaration>(3);
            RegisterType<IInterfaceDeclaration>(4);
            RegisterType<IFunctionDeclaration>(5);

            ReplaceWithChildren<INamespaceBody>();
            ReplaceWithChildren<IClassBody>();
        }

        public static int GetTypeId([NotNull] ITreeNode node)
        {
            foreach (var (type, id) in KnownTypes)
            {
                if (type.IsInstanceOfType(node))
                {
                    return id;
                }
            }

            return 0;
        }

        public static bool ShouldAddToModel([NotNull] ITreeNode node) => GetTypeId(node) != 0;

        public static bool ShouldVisitChildren([NotNull] ITreeNode node) =>
            GetTypeId(node) != 0 || TypesToReplaceWithChildren.Any(it => it.IsInstanceOfType(node));
    }
}
