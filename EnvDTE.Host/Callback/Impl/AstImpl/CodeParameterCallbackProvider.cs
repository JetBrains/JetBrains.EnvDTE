using System;
using JetBrains.Application.Parts;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.AstImpl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public class CodeParameterCallbackProvider(AstManager astManager, ProjectModelViewHost host)
        : CodeElementCallbackProviderBase(astManager, host)
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
