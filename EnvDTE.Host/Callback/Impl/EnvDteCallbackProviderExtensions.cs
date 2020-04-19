using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.Rd.Tasks;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Resources.Shell;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    public static class EnvDteCallbackProviderExtensions
    {
        public static void SetWithReadLock<TRes>(this IRdEndpoint<Unit, TRes> endpoint, Func<TRes> func) =>
            endpoint.Set(
                _ =>
                {
                    using (ReadLockCookie.Create())
                    {
                        return func();
                    }
                }
            );

        public static void SetWithReadLock<TReq, TRes>(this IRdEndpoint<TReq, TRes> endpoint, Func<TReq, TRes> func) =>
            endpoint.Set(
                argument =>
                {
                    using (ReadLockCookie.Create())
                    {
                        return func(argument);
                    }
                }
            );

        [NotNull, ItemNotNull]
        public static IEnumerable<ITreeNode> GetEnvDTEModelChildren([NotNull] this ITreeNode node)
        {
            foreach (var directChild in node.Children())
            {
                if (PsiElementRegistrar.ShouldAddToModel(directChild))
                {
                    yield return directChild;
                }
                else if (PsiElementRegistrar.ShouldVisitChildren(directChild))
                {
                    foreach (var modelChild in GetEnvDTEModelChildren(directChild))
                    {
                        yield return modelChild;
                    }
                }
            }
        }

        [CanBeNull]
        public static ITreeNode GetEnvDTEModelParent([NotNull] this ITreeNode node)
        {
            var current = node;
            do
            {
                if (PsiElementRegistrar.ShouldAddToModel(current)) return current;
                current = current.Parent;
            }
            while (current != null);

            return null;
        }
    }
}
