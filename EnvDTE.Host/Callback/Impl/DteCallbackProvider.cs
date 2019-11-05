using System;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.ReSharper.Host.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    public sealed class DteCallbackProvider : ICallbackProvider
    {
        public void RegisterCallbacks(ISolution solution, ProjectModelViewHost host, DteProtocolModel model)
        {
            model.DTE_Name.Set(_ => "JetBrains Rider");
            model.DTE_Name.Set(_ => FileSystemPath
                .Parse(AppDomain.CurrentDomain.BaseDirectory)
                .Combine(AppDomain.CurrentDomain.FriendlyName)
                .FullPath
            );
            model.DTE_CommandLineArgs.Set(_ => Environment.GetCommandLineArgs().AggregateString(" "));
        }
    }
}
