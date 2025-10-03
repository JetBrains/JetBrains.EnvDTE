using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModel
{
    public sealed class ProjectsImplementation(
        [NotNull] DteImplementation dte,
        [NotNull, ItemNotNull] IReadOnlyList<Rider.Model.ProjectModel> projectModels)
        : Projects
    {
        [NotNull]
        public DTE Parent => dte;

        public int Count => projectModels.Count;

        [NotNull]
        public DTE DTE => dte;

        [NotNull]
        IEnumerator Projects.GetEnumerator() => projectModels
            .Select(model => new ProjectImplementation(dte, model))
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => (this as Projects).GetEnumerator();

        [NotNull]
        public Project Item(object index)
        {
            if (index is not int number) throw new ArgumentException();
            return new ProjectImplementation(dte, projectModels[number]);
        }

        public Properties Properties => throw new NotImplementedException();
        public string Kind => throw new NotImplementedException();
    }
}
