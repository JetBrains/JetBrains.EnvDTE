using System;
using System.Linq;
using JetBrains.Application.Parts;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Impl;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.AstImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public class CodeElementCallbackProvider(AstManager astManager, ProjectModelViewHost host)
        : CodeElementCallbackProviderBase(astManager, host)
    {
        protected override void DoRegisterCallbacks(ProjectModelViewHost host, DteProtocolModel model)
        {
            MapWithAstManager(
                model.CodeElement_get_Children,
                node => node.GetEnvDTEModelChildren().Select(CreateCodeElementModel).ToList(),
                element => throw new NotImplementedException(),
                type => throw new InvalidOperationException()
            );
            MapWithAstManager(
                model.CodeElement_get_Access,
                GetAccessRights,
                GetAccessRights,
                type => throw new NotImplementedException());
            MapWithAstManager(
                model.CodeElement_get_Name,
                TreeNodeExtensions.FindName,
                element => element.ShortName,
                type => type.GetPresentableName(CSharpLanguage.Instance.NotNull())
            );
            MapWithAstManager(
                model.CodeElement_get_FullName,
                node =>
                {
                    if (!(node is ICSharpDeclaration declaration)) return null;
                    return CSharpSharedImplUtil.GetQualifiedName(declaration);
                },
                element => Switch(
                    element,
                    ns => ns.QualifiedName,
                    type => type.GetClrName().FullName,
                    function => $"{function.ContainingType.NotNull().GetClrName().FullName}.{function.ShortName}"
                ),
                type => type.GetLongPresentableName(CSharpLanguage.Instance.NotNull())
            );
            MapWithAstManager(
                model.CodeElement_get_ProjectItem,
                node =>
                {
                    var sourceFile = node.GetSourceFile();
                    var projectFile = sourceFile.ToProjectFile().NotNull();
                    return new ProjectItemModel(host.GetIdByItem(projectFile));
                },
                element => throw new NotImplementedException(),
                type => throw new InvalidOperationException()
            );
            MapWithAstManager(
                model.CodeElement_get_Parent,
                node =>
                {
                    var parent = node.GetEnvDTEModelParent();
                    if (parent == null) return null;
                    return CreateCodeElementModel(parent);
                },
                element => Switch(
                    element,
                    _ => null,
                    type => ToModel(type.GetContainingNamespace()),
                    _ => null
                ),
                type => throw new InvalidOperationException()
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
