using System;
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
            MapWithAstManager(
                model.CodeElement_get_Bases,
                node =>
                {
                    if (!(node is ITypeDeclaration typeDeclaration))
                    {
                        throw new InvalidOperationException("Tried to find base for non-class element");
                    }

                    return GetSuperTypes(typeDeclaration.DeclaredElement).AsList();
                },
                element =>
                {
                    if (!(element is ITypeElement type))
                    {
                        throw new InvalidOperationException("Tried to find base for non-class element");
                    }

                    return GetSuperTypes(type).AsList();
                }
            );

            MapWithAstManager(
                model.CodeElement_get_Namespace,
                node =>
                {
                    if (!(node is ICSharpTypeDeclaration typeDeclaration))
                    {
                        throw new InvalidOperationException("Tried to find namespace for non-class element");
                    }

                    return CreateNamespaceModel(typeDeclaration);
                },
                element =>
                {
                    if (!(element is ITypeElement type))
                    {
                        throw new InvalidOperationException("Tried to find namespace for non-class element");
                    }

                    return ToModel(type.GetContainingNamespace());
                }
            );

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
