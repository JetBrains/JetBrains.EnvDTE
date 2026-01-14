using System;
using JetBrains.Application.Parts;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    [SolutionComponent(Instantiation.DemandAnyThreadSafe)]
    public class DteCallbackProvider : IEnvDteCallbackProvider
    {
        public void RegisterCallbacks(DteProtocolModel model)
        {
            model.DTE_Name.SetSync(_ => "JetBrains Rider");
            model.DTE_FileName.SetSync(_ => FileSystemPath
                .Parse(AppDomain.CurrentDomain.BaseDirectory)
                .Combine(AppDomain.CurrentDomain.FriendlyName)
                .FullPath
            );
            model.DTE_CommandLineArgs.SetSync(_ => Environment.GetCommandLineArgs().AggregateString(" "));
        }
    }
}
