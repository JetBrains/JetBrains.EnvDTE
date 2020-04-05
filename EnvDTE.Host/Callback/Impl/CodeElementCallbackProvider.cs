using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Impl;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class CodeElementCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            GlobalAstManager globalAstManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            AstManager GetManager(CodeElementModel codeElementModel) => globalAstManager
                .GetOrCreate(host.GetItemById<IProjectFile>(codeElementModel.ContainingFile.Id).NotNull());

            model.CodeElement_get_Children.SetWithReadLock(codeElementModel =>
            {
                var astManager = GetManager(codeElementModel);
                var node = astManager.GetElement(codeElementModel.Id);
                var query =
                    from child in node.GetEnvDTEModelChildren()
                    let childId = astManager.GetOrCreateId(child)
                    let childTypeId = PsiElementRegistrar.GetTypeId(child)
                    select new CodeElementModel(childTypeId, codeElementModel.ContainingFile, childId, true);
                return query.ToList();
            });
            model.CodeElement_get_Access.SetWithReadLock(codeElementModel =>
            {
                var astManager = GetManager(codeElementModel);
                var node = astManager.GetElement(codeElementModel.Id);
                if (!(node is IAccessRightsOwner @class)) return Access.None;
                return @class.GetAccessRights() switch {
                    AccessRights.PUBLIC => Access.Public,
                    AccessRights.INTERNAL => Access.Internal,
                    AccessRights.PROTECTED => Access.Protected,
                    AccessRights.PROTECTED_OR_INTERNAL => Access.ProtectedInternal,
                    AccessRights.PROTECTED_AND_INTERNAL => Access.ProtectedInternal,
                    AccessRights.PRIVATE => Access.Private,
                    _ => Access.None
                };
            });
            model.CodeElement_get_Name.SetWithReadLock(codeElementModel =>
            {
                var astManager = GetManager(codeElementModel);
                var element = astManager.GetElement(codeElementModel.Id);
                return ElementNameProvider.FindName(element);
            });
            model.CodeElement_get_FullName.SetWithReadLock(codeElementModel =>
            {
                var astManager = GetManager(codeElementModel);
                var element = astManager.GetElement(codeElementModel.Id);
                if (!(element is ICSharpDeclaration node)) return null;
                return CSharpSharedImplUtil.GetQualifiedName(node);
            });
            model.CodeElement_get_Bases.SetWithReadLock(codeElementModel =>
            {
                var astManager = GetManager(codeElementModel);
                var element = astManager.GetElement(codeElementModel.Id);
                if (!(element is IClassDeclaration classDeclaration))
                {
                    throw new InvalidOperationException("Tried to find base for non-class element");
                }

                CodeElementModel ToModel(IList<IDeclaration> declarations)
                {
                    if (declarations.IsEmpty())
                    {
                        // TODO: return detached model
                        return null;
                    }

                    if (declarations.IsSingle())
                    {
                        var declaration = declarations.Single();
                        var projectFile = declaration.GetSourceFile().ToProjectFile().NotNull();
                        int id = astManager.GetOrCreateId(declaration);
                        int typeId = PsiElementRegistrar.GetTypeId(declaration);
                        return new CodeElementModel(typeId, new ProjectItemModel(host.GetIdByItem(projectFile)), id, true);
                    }

                    return null;
                }

                var query = from type in classDeclaration.DeclaredElement.NotNull().GetSuperTypes()
                    let typeElement = type.GetTypeElement()
                    where typeElement != null
                    let declarations = typeElement.GetDeclarations()
                    let child = ToModel(declarations)
                    where child != null
                    select child;

                return query.AsList();
            });
        }
    }
}
