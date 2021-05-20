using System;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class DteCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(
            AstManager astManager,
            ISolution solution,
            ProjectModelViewHost host,
            DteProtocolModel model
        )
        {
            model.DTE_Name.SetWithReadLock(() => "JetBrains Rider");
            model.DTE_FileName.SetWithReadLock(() => FileSystemPath
                .Parse(AppDomain.CurrentDomain.BaseDirectory)
                .Combine(AppDomain.CurrentDomain.FriendlyName)
                .FullPath
            );
            model.DTE_CommandLineArgs.SetWithReadLock(() => Environment.GetCommandLineArgs().AggregateString(" "));
        }
    }
}
