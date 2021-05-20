using System;
using JetBrains.Diagnostics;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class CodeFunctionCallbackProvider : CodeElementCallbackProviderBase
    {
        protected override void DoRegisterCallbacks(ProjectModelViewHost host, DteProtocolModel model)
        {
            MapWithAstManager<IFunctionDeclaration, IFunction, CodeElementModel>(
                model.CodeFunction_get_Type,
                node => ToModel(node.DeclaredElement.NotNull().ReturnType),
                function => ToModel(function.ReturnType),
                type => throw new InvalidOperationException()
            );
        }
    }
}
