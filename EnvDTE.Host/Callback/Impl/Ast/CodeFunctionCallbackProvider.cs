using System;
using JetBrains.Application.Parts;
using JetBrains.Application.Threading;
using JetBrains.Diagnostics;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Ast
{
    [SolutionComponent(InstantiationEx.LegacyDefault)]
    public sealed class CodeFunctionCallbackProvider : CodeElementCallbackProviderBase
    {
        protected override void DoRegisterCallbacks(ProjectModelViewHost host, IShellLocks locks, DteProtocolModel model)
        {
            MapWithAstManager<IFunctionDeclaration, IFunction, CodeElementModel>(
                model.CodeFunction_get_Type,
                locks,
                node => ToModel(node.DeclaredElement.NotNull().ReturnType),
                function => ToModel(function.ReturnType),
                type => throw new InvalidOperationException()
            );
        }
    }
}
