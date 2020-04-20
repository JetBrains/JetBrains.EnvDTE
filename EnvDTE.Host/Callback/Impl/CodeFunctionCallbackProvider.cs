using System;
using JetBrains.Annotations;
using JetBrains.Diagnostics;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
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
            MapWithAstManager(
                model.CodeFunction_get_Type,
                node =>
                {
                    if (!(node is IFunctionDeclaration declaration))
                    {
                        throw new InvalidOperationException("Attempted to get a type of not a function");
                    }

                    return CreateTypeModel(declaration.DeclaredElement.NotNull());
                },
                element =>
                {
                    if (!(element is IFunction function))
                    {
                        throw new InvalidOperationException("Attempted to get a type of not a function");
                    }

                    return CreateTypeModel(function);
                }
            );
        }

        [CanBeNull]
        private CodeElementModel CreateTypeModel([NotNull] IFunction function) =>
            ToModel(function.ReturnType.GetScalarType().NotNull().GetTypeElement().NotNull());
    }
}
