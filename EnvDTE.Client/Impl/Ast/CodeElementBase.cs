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

        public vsCMAccess Access
        {
            get => Implementation.DteProtocolModel.CodeElement_get_Access.Sync(Model) switch
            {
                Rider.Model.Access.Public => vsCMAccess.vsCMAccessPublic,
                Rider.Model.Access.Private => vsCMAccess.vsCMAccessPrivate,
                Rider.Model.Access.Protected => vsCMAccess.vsCMAccessProtected,
                Rider.Model.Access.Internal => vsCMAccess.vsCMAccessProject,
                Rider.Model.Access.ProtectedInternal => vsCMAccess.vsCMAccessProjectOrProtected,
                Rider.Model.Access.PrivateProtected => vsCMAccess.vsCMAccessProtected,
                Rider.Model.Access.None => vsCMAccess.vsCMAccessDefault,
                _ => vsCMAccess.vsCMAccessDefault
            };
            set => throw new NotImplementedException();
        }
    }
}
