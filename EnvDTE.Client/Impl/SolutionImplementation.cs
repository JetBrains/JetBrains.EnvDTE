using System;
using System.Collections;
using System.Collections.Generic;
using com.jetbrains.rider.model;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Core;

namespace JetBrains.EnvDTE.Client.Impl
{
    public sealed class SolutionImplementation : SolutionClass
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        [NotNull, ItemNotNull]
        private List<ProjectModel> ProjectModels => Implementation
            .DteProtocolModel
            .Solution_get_Projects
            .Sync(Unit.Instance);

        internal SolutionImplementation([NotNull] DteImplementation dte) => Implementation = dte;
        public override DTE DTE => Implementation;
        public override DTE Parent => Implementation;
        public override string FileName => Implementation.DteProtocolModel.Solution_FileName.Sync(Unit.Instance);
        public override string FullName => FileName;

        public override Project Item(object index)
        {
            if (!(index is int number)) throw new ArgumentException();
            var item = Implementation.DteProtocolModel.Solution_Item.Sync(number);
            if (item.Id == -1) throw new ArgumentException();
            return new ProjectImplementation(Implementation, item);
        }

        public override int Count => Implementation.DteProtocolModel.Solution_Count.Sync(Unit.Instance);
        public override Projects Projects => new ProjectsImplementation(Implementation, ProjectModels);
        public override IEnumerator GetEnumerator() => Projects.GetEnumerator();
    }
}
