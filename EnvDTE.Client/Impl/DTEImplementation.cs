using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Core;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl
{
    [UsedImplicitly]
    public sealed class DTEImplementation : DTEClass
    {
        public DTEImplementation([NotNull] DteProtocolModel dteProtocolModel)
        {
            DteProtocolModel = dteProtocolModel;
            Solution = new SolutionImplementation(this);
        }

        [NotNull]
        internal DteProtocolModel DteProtocolModel { get; }

        [NotNull]
        public override DTE DTE => this;

        [NotNull]
        public override string Name => DteProtocolModel.DTE_Name.Sync(Unit.Instance);

        [NotNull]
        public override string FileName => DteProtocolModel.DTE_FileName.Sync(Unit.Instance);

        [NotNull]
        public override string FullName => FileName;

        public override vsIDEMode Mode => vsIDEMode.vsIDEModeDesign;

        [NotNull]
        public override Solution Solution { get; } // Initialized in constructor
    }
}
