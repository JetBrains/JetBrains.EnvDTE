using System.Collections.Generic;
using System.Linq;
using JetBrains.Diagnostics;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class CodeTypeCallbackProvider : CodeElementCallbackProviderBase
    {
        protected override void DoRegisterCallbacks(
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            MapWithAstManager<ITypeDeclaration, ITypeElement, List<CodeElementModel>>(
                model.CodeElement_get_Bases,
                node => GetSuperTypes(node.DeclaredElement).AsList(),
                element => GetSuperTypes(element).AsList());

            MapWithAstManager<ICSharpTypeDeclaration, ITypeElement, CodeElementModel>(
                model.CodeElement_get_Namespace,
                CreateNamespaceModel,
                element => ToModel(element.GetContainingNamespace()));

            IEnumerable<CodeElementModel> GetSuperTypes(ITypeElement declaredType) =>
                from type in declaredType.NotNull().GetSuperTypes()
                let typeElement = type.GetTypeElement()
                where typeElement != null
                let child = ToModel(typeElement)
                where child != null
                select child;
        }
    }
}
