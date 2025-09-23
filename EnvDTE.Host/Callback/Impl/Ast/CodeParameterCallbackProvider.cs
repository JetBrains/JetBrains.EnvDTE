using System;
using JetBrains.Application.Parts;
using JetBrains.Diagnostics;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Ast
{
    [SolutionComponent(InstantiationEx.LegacyDefault)]
    public sealed class CodeParameterCallbackProvider : CodeElementCallbackProviderBase
    {
        protected override void DoRegisterCallbacks(ProjectModelViewHost host, DteProtocolModel model)
        {
            MapWithAstManager<IParameterDeclaration, IParameter, CodeElementModel>(
                model.CodeParameter_get_Type,
                node => ToModel(node.DeclaredElement.NotNull().Type),
                parameter => ToModel(parameter.Type),
                type => throw new InvalidOperationException()
            );
        }
    }
}
