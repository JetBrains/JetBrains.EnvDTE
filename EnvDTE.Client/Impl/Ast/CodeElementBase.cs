using System;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.Model;
using JetBrains.EnvDTE.Client.Impl.ProjectModel;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public abstract class CodeElementBase
    {
        [NotNull]
        protected CodeElementModel Model { get; }

        [NotNull]
        protected DteImplementation Implementation { get; }

        [NotNull]
        public DTE DTE => Implementation;

        protected CodeElementBase([NotNull] DteImplementation implementation, [NotNull] CodeElementModel model)
        {
            Implementation = implementation;
            Model = model;
        }

        [CanBeNull]
        public string Name
        {
            get => Model.Name;
            set => throw new NotImplementedException();
        }

        [NotNull]
        public CodeElements Children => new CodeElementsImplementation(
            Implementation,
            this,
            Implementation.DteProtocolModel.CodeElement_get_Children.Sync(Model)
        );

        [NotNull]
        public CodeElements Collection => Children;

        [NotNull]
        public CodeElements Members => Children;

        [NotNull]
        public ProjectItem ProjectItem => new ProjectItemImplementation(Implementation, Model.ContainingFile);
    }
}
