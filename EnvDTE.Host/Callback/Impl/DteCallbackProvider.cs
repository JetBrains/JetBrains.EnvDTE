using System;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent]
    public sealed class DteCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(ConnectionManager manager,
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
