using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
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
        [NotNull]
        private ILogger Logger { get; } = JetBrains.Util.Logging.Logger.GetLogger<CodeElementCallbackProvider>();

        public void RegisterCallbacks(
            AstManager astManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            void MapWithAstManager<TRes>(
                IRdEndpoint<CodeElementModel, TRes> ep,
                Func<ITreeNode, TRes> psiMapper,
                Func<IDeclaredElement, TRes> declaredElementMapper = null
            ) => ep.SetWithReadLock(codeElementModel => astManager.MapElement(
                codeElementModel.Id,
                psiMapper,
                declaredElementMapper ?? (element => throw new NotImplementedException())
            ));

            MapWithAstManager(
                model.CodeElement_get_Children,
                node => (
                    from child in node.GetEnvDTEModelChildren()
                    let childId = astManager.GetOrCreateId(child)
                    let childTypeId = PsiElementRegistrar.GetTypeId(child)
                    select new CodeElementModel(childTypeId, childId)
                ).ToList()
            );
            MapWithAstManager(model.CodeElement_get_Access, GetAccessRights, GetAccessRights);
            MapWithAstManager(
                model.CodeElement_get_Name,
                ElementNameProvider.FindName,
                element => element.ShortName
            );
            MapWithAstManager(
                model.CodeElement_get_FullName,
                node =>
                {
                    if (!(node is ICSharpDeclaration declaration)) return null;
                    return CSharpSharedImplUtil.GetQualifiedName(declaration);
                }
            );
            MapWithAstManager(
                model.CodeElement_get_Bases,
                node =>
                {
                    if (!(node is IClassDeclaration classDeclaration))
                    {
                        throw new InvalidOperationException("Tried to find base for non-class element");
                    }

                    CodeElementModel ToModel(IList<IDeclaration> declarations, ITypeElement typeElement)
                    {
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

                    var query = from type in classDeclaration.DeclaredElement.NotNull().GetSuperTypes()
                        let typeElement = type.GetTypeElement()
                        where typeElement != null
                        let declarations = typeElement.GetDeclarations()
                        let child = ToModel(declarations, typeElement)
                        where child != null
                        select child;

                    return query.AsList();
                }
            );
            MapWithAstManager(
                model.CodeElement_get_ProjectItem,
                node =>
                {
                    var sourceFile = node.GetSourceFile();
                    var projectFile = sourceFile.ToProjectFile().NotNull();
                    return new ProjectItemModel(host.GetIdByItem(projectFile));
                }
            );
        }

        private static Access GetAccessRights(object node)
        {
            if (!(node is IAccessRightsOwner owner)) return Access.None;
            return owner.GetAccessRights() switch
            {
                AccessRights.PUBLIC => Access.Public,
                AccessRights.INTERNAL => Access.Internal,
                AccessRights.PROTECTED => Access.Protected,
                AccessRights.PROTECTED_OR_INTERNAL => Access.ProtectedInternal,
                AccessRights.PROTECTED_AND_INTERNAL => Access.ProtectedInternal,
                AccessRights.PRIVATE => Access.Private,
                _ => Access.None
            };
        }
    }
}
