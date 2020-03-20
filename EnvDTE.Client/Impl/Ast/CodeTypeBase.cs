using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public abstract class CodeTypeBase : CodeElementBase<TypeModel>
    {
        protected CodeTypeBase(
            [NotNull] DteImplementation implementation,
            [NotNull] TypeModel model
        ) : base(implementation, model)
        {
        }

        protected sealed override IReadOnlyList<CodeElementModel> GetChildren(TypeModel model)
        {
            IReadOnlyList<CodeElementModel> methods = model.Methods;
            return methods.Concat(model.Properties).Concat(model.NestedTypes).ToList();
        }
    }
}
