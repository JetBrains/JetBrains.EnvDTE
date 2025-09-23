using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.Diagnostics;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Ast
{
    [SolutionComponent(InstantiationEx.LegacyDefault)]
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
                element => GetSuperTypes(element).AsList(),
                type => new List<CodeElementModel>
                {
                    ToModel(TypeFactory.CreateTypeByCLRName("System.Array", type.Module))
                }
            );

            MapWithAstManager<ICSharpTypeDeclaration, ITypeElement, CodeElementModel>(
                model.CodeElement_get_Namespace,
                CreateNamespaceModel,
                element => ToModel(element.GetContainingNamespace()),
                type => throw new NotImplementedException()
            );

            IEnumerable<CodeElementModel> GetSuperTypes(ITypeElement declaredType) =>
                from typeElement in declaredType.NotNull().GetSuperTypeElements()
                where typeElement != null
                let child = ToModel(typeElement)
                where child != null
                select child;
        }
    }
}
