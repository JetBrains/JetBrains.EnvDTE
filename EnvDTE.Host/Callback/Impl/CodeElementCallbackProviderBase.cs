using System;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    public abstract class CodeElementCallbackProviderBase : IEnvDteCallbackProvider
    {
        [NotNull]
        private ILogger Logger { get; } = JetBrains.Util.Logging.Logger.GetLogger<CodeElementCallbackProvider>();

        private AstManager AstManager { get; set; }

        public void RegisterCallbacks(
            AstManager astManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            AstManager = astManager;
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
            int id = AstManager.GetOrCreateId(ns);
            int typeId = PsiElementRegistrar.GetTypeId(ns);
            return new CodeElementModel(typeId, id);
        }

        protected void MapWithAstManager<TRes>(
            [NotNull] IRdEndpoint<CodeElementModel, TRes> ep,
            [NotNull] Func<ITreeNode, TRes> psiMapper,
            [NotNull] Func<IDeclaredElement, TRes> declaredElementMapper
        ) => ep.SetWithReadLock(codeElementModel => AstManager.MapElement(
            codeElementModel.Id,
            psiMapper,
            declaredElementMapper
        ));

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
            int childId = AstManager.GetOrCreateId(node);
            int childTypeId = PsiElementRegistrar.GetTypeId(node);
            return new CodeElementModel(childTypeId, childId);
        }

        [CanBeNull]
        protected CodeElementModel ToModel([NotNull] IDeclaredElement typeElement)
        {
            var declarations = typeElement.GetDeclarations();
            if (declarations.IsEmpty())
            {
                int id = AstManager.GetOrCreateId(typeElement);
                int typeId = PsiElementRegistrar.GetTypeId(typeElement);
                return new CodeElementModel(typeId, id);
            }

            if (declarations.IsSingle())
            {
                var declaration = declarations.Single();
                int id = AstManager.GetOrCreateId(declaration);
                int typeId = PsiElementRegistrar.GetTypeId(declaration);
                return new CodeElementModel(typeId, id);
            }

            Logger.Warn("Failed to create a model for base class because it resides in multiple locations");
            return null;
        }
    }
}
