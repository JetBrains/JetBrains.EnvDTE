using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl
{
    public sealed class ProjectsImplementation(
        [NotNull] DteImplementation dte,
        [NotNull, ItemNotNull] IReadOnlyList<ProjectItemModel> projectModels)
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
            var i = ImplementationUtil.GetValidIndexOrThrow(index, projectModels.Count);
            return new ProjectImplementation(dte, projectModels[i]);
        }

        internal ProjectImplementation Item(ProjectItemModel projectModel) => new (dte, projectModel);

        #region NotImplemented

        public Properties Properties => throw new NotImplementedException();
        public string Kind => throw new NotImplementedException();

        #endregion
    }
}
