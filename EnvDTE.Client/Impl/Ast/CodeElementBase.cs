using System;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Model;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public abstract class CodeElementBase<TModel> where TModel : CodeElementModel
    {
        [NotNull]
        protected TModel Model { get; }

        [NotNull]
        private DteImplementation Implementation { get; }

        [NotNull]
        public DTE DTE => Implementation;

        protected CodeElementBase([NotNull] DteImplementation implementation, [NotNull] TModel model)
        {
            Implementation = implementation;
            Model = model;
        }

        [NotNull]
        public string Name
        {
            get => Model.Name;
            set => throw new NotImplementedException();
        }

        [NotNull]
        public CodeElements Children => new CodeElementsImplementation(Implementation, this, GetChildren(Model));

        [NotNull, ItemNotNull]
        protected abstract IReadOnlyList<CodeElementModel> GetChildren([NotNull] TModel model);
    }
}
