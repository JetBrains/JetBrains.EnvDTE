using System;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Collections.Viewable;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Psi.Util;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.AstImpl
{
    public abstract class CodeElementCallbackProviderBase(
        AstManager astManager,
        ProjectModelViewHost host)
        : IEnvDteCallbackProvider
    {
        [NotNull]
        private ILogger Logger { get; } = JetBrains.Util.Logging.Logger.GetLogger<CodeElementCallbackProvider>();

        public void RegisterCallbacks(DteProtocolModel model, IScheduler scheduler)
        {
            DoRegisterCallbacks(host, model);
        }

        protected abstract void DoRegisterCallbacks(
            [NotNull] ProjectModelViewHost host,
            [NotNull] DteProtocolModel model
        );

        [NotNull]
        protected CodeElementModel CreateNamespaceModel([NotNull] ICSharpTypeDeclaration declaration)
        {
            var ns = declaration.OwnerNamespaceDeclaration;
            int id = astManager.GetOrCreateId(ns);
            int typeId = PsiElementRegistrar.GetTypeId(ns);
            return new CodeElementModel(typeId, id);
        }

        protected void MapWithAstManager<TRes>(
            [NotNull] IRdEndpoint<CodeElementModel, TRes> ep,
            [NotNull] Func<ITreeNode, TRes> psiMapper,
            [NotNull] Func<IDeclaredElement, TRes> declaredElementMapper,
            [NotNull] Func<IType, TRes> typeMapper
        ) => MapWithAstManager<ITreeNode, IDeclaredElement, TRes>(ep, psiMapper, declaredElementMapper,
            typeMapper);

        protected void MapWithAstManager<TNode, TElement, TRes>(
            [NotNull] IRdEndpoint<CodeElementModel, TRes> ep,
            [NotNull] Func<TNode, TRes> psiMapper,
            [NotNull] Func<TElement, TRes> declaredElementMapper,
            [NotNull] Func<IArrayType, TRes> typeMapper
        )
            where TNode : ITreeNode
            where TElement : IDeclaredElement =>
            ep.SetAsync((lifetime, model) =>
                lifetime.StartReadActionAsync(() => astManager.MapElement(
                    model.Id,
                    psiMapper,
                    declaredElementMapper,
                    typeMapper
                )));

        // More type-safe and change-resistant and less error-prone than the usual switch
        [CanBeNull]
        protected static TResult Switch<TResult>(
            [NotNull] IDeclaredElement element,
            Func<INamespace, TResult> namespaceMapper,
            Func<ITypeElement, TResult> typeMapper,
            Func<IFunction, TResult> functionMapper
        ) => element switch
        {
            INamespace ns => namespaceMapper(ns),
            ITypeElement type => typeMapper(type),
            IFunction function => functionMapper(function),
            _ => default
        };

        [NotNull]
        protected CodeElementModel CreateCodeElementModel([NotNull] ITreeNode node)
        {
            int childId = astManager.GetOrCreateId(node);
            int childTypeId = PsiElementRegistrar.GetTypeId(node);
            return new CodeElementModel(childTypeId, childId);
        }

        [CanBeNull]
        protected CodeElementModel ToModel([NotNull] IDeclaredElement typeElement)
        {
            var declarations = typeElement.GetDeclarations();
            if (declarations.IsEmpty())
            {
                int id = astManager.GetOrCreateId(typeElement);
                int typeId = PsiElementRegistrar.GetTypeId(typeElement);
                return new CodeElementModel(typeId, id);
            }

            if (declarations.IsSingle())
            {
                var declaration = declarations.Single();
                int id = astManager.GetOrCreateId(declaration);
                int typeId = PsiElementRegistrar.GetTypeId(declaration);
                return new CodeElementModel(typeId, id);
            }

            Logger.Warn("Failed to create a model for base class because it resides in multiple locations");
            return null;
        }

        [CanBeNull]
        protected CodeElementModel ToModel([NotNull] IType type)
        {
            var element = type.GetTypeElement();
            if (element != null) return ToModel(element);
            int id = astManager.GetOrCreateId((IArrayType)type);
            return new CodeElementModel(PsiElementRegistrar.ClassDeclarationId, id);
        }
    }
}
