using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Client.Impl.Model
{
    public sealed class CodeElementsImplementation : CodeElements
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        [NotNull]
        private EnvDTEElementRegistrar Registrar { get; }

        [NotNull, ItemNotNull]
        private IReadOnlyList<CodeElementModel> CodeElementModels { get; }

        public CodeElementsImplementation(
            [NotNull] DteImplementation implementation,
            object parent,
            [NotNull, ItemNotNull] IReadOnlyList<CodeElementModel> codeElementModels
        )
        {
            Implementation = implementation;
            Parent = parent;
            Registrar = new EnvDTEElementRegistrar(Implementation);
            CodeElementModels = codeElementModels;
        }

        [NotNull]
        public DTE DTE => Implementation;

        public object Parent { get; }
        public int Count => CodeElementModels.Count;

        public IEnumerator GetEnumerator() => CodeElementModels.SelectNotNull(Registrar.Convert).GetEnumerator();

        [CanBeNull]
        public CodeElement Item([NotNull] object index)
        {
            if (!(index is int number)) throw new ArgumentException();
            return Registrar.Convert(CodeElementModels[number]);
        }

        public void Reserved1(object Element) => throw new NotImplementedException();
        public bool CreateUniqueID(string Prefix, string NewName = "0") => throw new NotImplementedException();
    }
}
