using System;
using JetBrains.Annotations;
using JetBrains.Application.Components;
using JetBrains.Application.Parts;
using JetBrains.Core;
using JetBrains.EnvDTE.Host.Manager;
using JetBrains.IDE;
using JetBrains.IDE.Common;
using JetBrains.ProjectModel;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.Documents;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.RdBackend.Common.Features.TextControls;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.IDE;

[SolutionComponent(Instantiation.DemandAnyThreadSafe)]
public class ItemOperationsCallbackProvider(
    ISolution solution,
    ISimpleLazy<IEditorManager> editorManager)
    : IEnvDteCallbackProvider
{
    public void RegisterCallbacks(DteProtocolModel model)
    {
        model.ItemOperations_open_File.SetAsync(async (lifetime, args) =>
        {
            var options = new OpenFileOptions(FileView: ParseFileView(args.ViewKind));
            await lifetime.StartMainReadAsync(async () => await editorManager.Value.OpenFileAsync(
                    VirtualFileSystemPath.Parse(args.FileName, InteractionContext.SolutionContext), options));

            return new IdeWindow();
        });

        model.ItemOperations_isOpen_File.SetAsync(async (lifetime, args) =>
        {
            var file = VirtualFileSystemPath.Parse(args.FileName, InteractionContext.SolutionContext);
            var options = new OpenFileOptions(FileView: ParseFileView(args.ViewKind));
            var location = options.ToTextControlLocation();

            return await lifetime.StartMainRead(() =>
            {
                var textControlId = TextControlModelIdUtil.CreateDefaultTextControlId(file, location, solution);
                var projectFile = DocumentHostProjectFileUtil.GetOrCreateProjectFile(solution, file, textControlId.DocumentId);
                return editorManager.Value.IsOpenedInTextControl(projectFile);
            });
        });
    }

    private static FileView ParseFileView([NotNull] string str) => str switch
    {
        "{00000000-0000-0000-0000-000000000000}" => FileView.Primary,
        "{FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF}" => FileView.TextView, // TextView is default
        "{7651A700-06E5-11D1-8EBD-00A0C90F26EA}" => FileView.Debugging,
        "{7651A701-06E5-11D1-8EBD-00A0C90F26EA}" => FileView.Code,
        "{7651A702-06E5-11D1-8EBD-00A0C90F26EA}" => FileView.Designer,
        "{7651A703-06E5-11D1-8EBD-00A0C90F26EA}" => FileView.TextView,
        _ => throw new ArgumentOutOfRangeException(nameof(str))
    };
}
