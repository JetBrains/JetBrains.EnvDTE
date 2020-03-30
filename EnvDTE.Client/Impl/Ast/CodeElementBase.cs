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

        [CanBeNull]
        public object Parent { get; }

        protected CodeElementBase(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        )
        {
            Implementation = implementation;
            Model = model;
            Parent = parent;
        }

        [CanBeNull]
        public string Name
        {
            get => Implementation.DteProtocolModel.CodeElement_get_Name.Sync(Model);
            set => throw new NotImplementedException();
        }


        [CanBeNull]
        public string FullName => Implementation.DteProtocolModel.CodeElement_get_FullName.Sync(Model);

        [NotNull]
        public CodeElements Children => new CodeElementsImplementation(
            Implementation,
            Implementation.DteProtocolModel.CodeElement_get_Children.Sync(Model),
            this,
            this
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
