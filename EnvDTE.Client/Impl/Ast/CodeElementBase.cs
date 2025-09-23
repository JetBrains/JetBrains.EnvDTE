using System;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Impl.ProjectModel;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Ast
{
    public abstract class CodeElementBase
    {
        [NotNull]
        protected EnvDTEElementRegistrar EnvDTEElementRegistrar { get; }

        [NotNull]
        protected CodeElementModel Model { get; }

        [NotNull]
        protected DteImplementation Implementation { get; }

        [NotNull]
        public DTE DTE => Implementation;

        [CanBeNull]
        private object CachedParent { get; set; }

        [CanBeNull]
        public object Parent => CachedParent ??= CreateParent();

        [CanBeNull]
        private object CreateParent()
        {
            var parentModel = Implementation.DteProtocolModel.CodeElement_get_Parent.Sync(Model);
            if (parentModel == null) return null;
            return EnvDTEElementRegistrar.Convert(parentModel, null);
        }

        protected CodeElementBase(
            [NotNull] DteImplementation implementation,
            [NotNull] CodeElementModel model,
            [CanBeNull] object parent
        )
        {
            Implementation = implementation;
            Model = model;
            CachedParent = parent;
            EnvDTEElementRegistrar = new EnvDTEElementRegistrar(Implementation);
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
            EnvDTEElementRegistrar,
            Implementation.DteProtocolModel.CodeElement_get_Children.Sync(Model),
            this
        );

        [NotNull]
        public CodeElements Collection => Children;

        [NotNull]
        public CodeElements Members => new CodeElementsOverList(
            Implementation,
            Children.Cast<CodeElement>().Where(it => !(it is CodeAttribute)).ToList(),
            this
        );

        [NotNull]
        public CodeElements Attributes => new CodeElementsOverList(
            Implementation,
            Children.Cast<CodeElement>().Where(it => it is CodeAttribute).ToList(),
            this
        );

        [NotNull]
        public ProjectItem ProjectItem => new ProjectItemImplementation(
            Implementation,
            Implementation.DteProtocolModel.CodeElement_get_ProjectItem.Sync(Model)
        );

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

        [CanBeNull]
        public string Language => Implementation
            .DteProtocolModel
            .ProjectItem_get_Language
            .Sync(Implementation.DteProtocolModel.CodeElement_get_ProjectItem.Sync(Model))
            .ToEnvDTELanguage();
    }
}
