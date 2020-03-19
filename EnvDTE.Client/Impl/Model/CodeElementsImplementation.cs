using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.Model
{
    public sealed class CodeElementsImplementation : CodeElements
    {
        [NotNull]
        private DteImplementation Implementation { get; }

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
            CodeElementModels = codeElementModels;
        }

        [NotNull]
        public DTE DTE => Implementation;

        public object Parent { get; }
        public int Count => CodeElementModels.Count;

        [NotNull]
        IEnumerator CodeElements.GetEnumerator() => CodeElementModels.GetEnumerator();

        public CodeElement Item(object index)
        {
            if (!(index is int number)) throw new ArgumentException();
            return new CodeElementImplementation(Implementation, ProjectModels[number]);
        }

        public void Reserved1(object Element)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateUniqueID(string Prefix, string NewName = "0") => throw new System.NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new System.NotImplementedException();
    }
}
