using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.Application.Threading;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.AstImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class CodeTypeCallbackProvider(ISolution solution, AstManager astManager, ProjectModelViewHost host)
        : CodeElementCallbackProviderBase(solution, astManager, host)
    {
        protected override void DoRegisterCallbacks(
            ProjectModelViewHost host,
            IShellLocks locks,
            DteProtocolModel model
        )
        {
            MapWithAstManager<ITypeDeclaration, ITypeElement, List<CodeElementModel>>(
                model.CodeElement_get_Bases,
                locks,
                node => GetSuperTypes(node.DeclaredElement).AsList(),
                element => GetSuperTypes(element).AsList(),
                type => new List<CodeElementModel>
                {
                    ToModel(TypeFactory.CreateTypeByCLRName("System.Array", type.Module))
                }
            );

            MapWithAstManager<ICSharpTypeDeclaration, ITypeElement, CodeElementModel>(
                model.CodeElement_get_Namespace,
                locks,
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
