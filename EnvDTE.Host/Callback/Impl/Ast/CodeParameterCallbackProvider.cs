using System;
using JetBrains.Application.Parts;
using JetBrains.Application.Threading;
using JetBrains.Diagnostics;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Ast
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class CodeParameterCallbackProvider(ISolution solution, AstManager astManager, ProjectModelViewHost host)
        : CodeElementCallbackProviderBase(solution, astManager, host)
    {
        protected override void DoRegisterCallbacks(
            ProjectModelViewHost host,
            IShellLocks locks,
            DteProtocolModel model)
        {
            MapWithAstManager<IParameterDeclaration, IParameter, CodeElementModel>(
                model.CodeParameter_get_Type,
                locks,
                node => ToModel(node.DeclaredElement.NotNull().Type),
                parameter => ToModel(parameter.Type),
                type => throw new InvalidOperationException()
            );
        }
    }
}
