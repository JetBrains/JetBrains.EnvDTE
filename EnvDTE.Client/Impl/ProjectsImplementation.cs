using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl
{
    public sealed class ProjectsImplementation : Projects
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        [NotNull, ItemNotNull]
        private IReadOnlyList<ProjectModel> ProjectModels { get; }

        public ProjectsImplementation(
            [NotNull] DteImplementation implementation,
            [NotNull, ItemNotNull] IReadOnlyList<ProjectModel> projectModels
        )
        {
            Implementation = implementation;
            ProjectModels = projectModels;
        }

        [NotNull]
        public DTE Parent => Implementation;

        public int Count => ProjectModels.Count;

        [NotNull]
        public DTE DTE => Implementation;

        [NotNull]
        IEnumerator Projects.GetEnumerator() => ProjectModels
            .Select(model => new ProjectImplementation(Implementation, model))
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => (this as Projects).GetEnumerator();

        [NotNull]
        public Project Item(object index)
        {
            if (!(index is int number)) throw new ArgumentException();
            return new ProjectImplementation(Implementation, ProjectModels[number]);
        }

        public Properties Properties => throw new NotImplementedException();
        public string Kind => throw new NotImplementedException();
    }
}
