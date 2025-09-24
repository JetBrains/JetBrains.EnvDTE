using System;
using JetBrains.Application.Parts;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent(InstantiationEx.LegacyDefault)]
    public sealed class DteCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            AstManager astManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            model.DTE_Name.SetWithReadLock(solution.Locks, () => "JetBrains Rider");
            model.DTE_FileName.SetWithReadLock(solution.Locks, () => FileSystemPath
                .Parse(AppDomain.CurrentDomain.BaseDirectory)
                .Combine(AppDomain.CurrentDomain.FriendlyName)
                .FullPath
            );
            model.DTE_CommandLineArgs.SetWithReadLock(solution.Locks, () =>
                Environment.GetCommandLineArgs().AggregateString(" "));
        }
    }
}
