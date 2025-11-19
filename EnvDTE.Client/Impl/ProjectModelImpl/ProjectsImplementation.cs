using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.EnvDTE.Client.Util;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl
{
    public sealed class ProjectsImplementation([NotNull] DteImplementation dte) : Projects
    {
        private List<ProjectItemModel> ProjectModels => dte.DteProtocolModel.Solution_get_Projects.Sync(Unit.Instance);

        [NotNull] public DTE Parent => dte;

        public int Count => dte.DteProtocolModel.Solution_Count.Sync(Unit.Instance);

        [NotNull] public DTE DTE => dte;

        [NotNull]
        IEnumerator Projects.GetEnumerator() => ProjectModels.Select(CreateProject).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => (this as Projects).GetEnumerator();

        [NotNull]
        public Project Item(object index)
        {
            var i = ImplementationUtil.GetValidIndexOrThrow(index, Count);
            return CreateProject(ProjectModels[i]);
        }

        internal ProjectImplementation Item(ProjectItemModel projectModel) => CreateProject(projectModel);

        private ProjectImplementation CreateProject(ProjectItemModel projectModel) =>
            ImplementationUtil.GetProjectImplementation(dte, projectModel);

        #region NotImplemented

        public Properties Properties => throw new NotImplementedException();
        public string Kind => throw new NotImplementedException();

        #endregion
    }
}
