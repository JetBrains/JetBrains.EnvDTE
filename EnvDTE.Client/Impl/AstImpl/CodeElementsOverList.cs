using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.AstImpl
{
    public sealed class CodeElementsOverList : CodeElements
    {
        [NotNull, ItemNotNull]
        private IReadOnlyList<CodeElement> CodeElements { get; }

        public CodeElementsOverList(
            [NotNull] DTE dte,
            [NotNull, ItemNotNull] IReadOnlyList<CodeElement> codeElements,
            [CanBeNull] object parent
        )
        {
            DTE = dte;
            Parent = parent;
            CodeElements = codeElements;
        }

        [NotNull]
        public DTE DTE { get; }

        [CanBeNull]
        public object Parent { get; }

        public int Count => CodeElements.Count;
        public IEnumerator GetEnumerator() => CodeElements.GetEnumerator();

        [NotNull]
        public CodeElement Item([NotNull] object index)
        {
            if (!(index is int number)) throw new ArgumentException();
            return CodeElements[number - 1];
        }

        public void Reserved1(object Element) => throw new NotImplementedException();
        public bool CreateUniqueID(string Prefix, string NewName = "0") => throw new NotImplementedException();
    }
}
