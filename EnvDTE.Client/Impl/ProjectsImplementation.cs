using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl
{
    public sealed class ProjectsImplementation : Projects
    {
        [NotNull]
        private DTEImplementation Implementation { get; }

        [NotNull, ItemNotNull]
        private IReadOnlyList<ProjectModel> Projects { get; }

        public ProjectsImplementation(
            [NotNull] DTEImplementation implementation,
            [NotNull, ItemNotNull] IReadOnlyList<ProjectModel> projects
        )
        {
            Implementation = implementation;
            Projects = projects;
        }

        [NotNull]
        public DTE Parent => Implementation;

        public int Count => Projects.Count;

        [NotNull]
        public DTE DTE => Implementation;

        [NotNull]
        IEnumerator Projects.GetEnumerator() => Projects.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Projects.GetEnumerator();

        [NotNull]
        public Project Item(object index)
        {
            if (!(index is int number)) throw new ArgumentException();
            return new ProjectImplementation(Implementation, Projects[number]);
        }

        public Properties Properties => throw new NotImplementedException();
        public string Kind => throw new NotImplementedException();
    }

}
