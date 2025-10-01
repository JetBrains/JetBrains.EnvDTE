using System;
using JetBrains.Application.Parts;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.ProjectModel;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public sealed class DteCallbackProvider(ISolution solution) : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(DteProtocolModel model)
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
