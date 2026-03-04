using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Application.Components;
using JetBrains.Application.Parts;
using JetBrains.Collections.Viewable;
using JetBrains.DataFlow;
using JetBrains.DocumentManagers.Transactions;
using JetBrains.DocumentManagers.Transactions.ProjectHostActions.Modifications;
using JetBrains.EnvDTE.Host.Callback.Util;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectImplementation.Structure;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.RdBackend.Common.Features.ProjectModel.FileNesting;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.Rider.Model;
using JetBrains.Util;

namespace JetBrains.EnvDTE.Host.Callback.Impl.ProjectModelImpl;

[SolutionComponent(Instantiation.DemandAnyThreadSafe)]
public class ProjectItemsCallbackProvider : IEnvDteCallbackProvider
{
    private readonly StringSuffixTree<HashSet<string>> _customNestingRules;
    [CanBeNull] private StringSuffixTree<HashSet<string>> _riderNestingRules;

    private readonly ILogger _logger;
    private readonly ISolution _solution;
    private readonly ProjectModelViewHost _host;
    private readonly ISimpleLazy<IProjectModelEditor> _projectModelEditor;

    public ProjectItemsCallbackProvider(
        Lifetime lifetime,
        ILogger logger,
        ISolution solution,
        ProjectModelViewHost host,
        ISimpleLazy<IProjectModelEditor> projectModelEditor,
        FileNestingHost fileNestingHost)
    {
        _logger = logger;
        _solution = solution;
        _host = host;
        _projectModelEditor = projectModelEditor;

        // Even though we do have Rider's nesting rules, the default set of rules is missing a rule that puts 'resx' files under code files.
        // This rule is really important for EF6, which generates resource files for migrations, and 'Update-Database' won't work
        // unless that file is nested properly under the code file (has a 'DependentUpon' metadata set).
        _customNestingRules = CreateNestingRules(
            (".resx", ".cs"),
            (".resx", ".vb"),
            (".resx", ".fs")
        );
        fileNestingHost.Rules.Change.Advise_HasNew(lifetime, x => _riderNestingRules = x.New);
    }

    public void RegisterCallbacks(DteProtocolModel model, IScheduler scheduler)
    {
        model.ProjectItems_addFolder.SetWithProjectFolderAsync(_host, AddFolderAsync);
        model.ProjectItems_addFromFile.SetWithProjectFolderAsync(_host, (lifetime, request, projectFolder) =>
            AddExistingItemAsync(lifetime, request, projectFolder));
        model.ProjectItems_addFromDirectory.SetWithProjectFolderAsync(_host, (lifetime, request, projectFolder) =>
            AddExistingItemAsync(lifetime, request, projectFolder, copyBeforeAdd: true));
        model.ProjectItems_addFromFileCopy.SetWithProjectFolderAsync(_host, (lifetime, request, projectFolder) =>
            AddExistingItemAsync(lifetime, request, projectFolder, copyBeforeAdd: true));
    }

    private async Task<ProjectItemModel> AddFolderAsync(Lifetime lifetime, ProjectItems_addFolderRequest request,
        IProjectFolder parentFolder)
    {
        _logger.Trace($"Adding folder '{request.Name}' to '{parentFolder.Location}'");

        var result = await lifetime.StartMainWrite(() =>
            _projectModelEditor.Value.AddFolder(parentFolder, request.Name));

        return result is null
            ? null
            : new ProjectItemModel(_host.GetIdByItem(result));
    }

    [CanBeNull]
    private string GetDependsUponFileName(VirtualFileSystemPath filePath)
    {
        var fileName = filePath.Name;
        var parentPath = filePath.Parent;

        var result =
            GetDependsUponFileNameBasedOnRules(_customNestingRules) ??
            GetDependsUponFileNameBasedOnRules(_riderNestingRules);

        _logger.Trace($"GetDependsUponFileName: {parentPath}, found: {result.QuoteIfNeeded()}");

        return result;

        string GetDependsUponFileNameBasedOnRules([CanBeNull] StringSuffixTree<HashSet<string>> nestingRules)
        {
            var suffixData = nestingRules?.FindLongestSuffix(fileName);
            if (suffixData is null) return null;

            var baseName = fileName.Substring(0, fileName.Length - suffixData.Value.SuffixLength);
            foreach (var parentSuffix in suffixData.Value.Data)
            {
                var dependsUponFiles = parentPath / (baseName + parentSuffix);

                if (dependsUponFiles.ExistsFile)
                    return dependsUponFiles.Name;
            }

            return null;
        }
    }

    private StringSuffixTree<HashSet<string>> CreateNestingRules(params (string Suffix, string NestUnderSuffix)[] rules)
    {
        var result = new StringSuffixTree<HashSet<string>>();
        foreach (var group in rules.GroupBy(x => x.Suffix))
        {
            result.Add(group.Key, group.Select(x => x.NestUnderSuffix).ToHashSet());
        }

        return result;
    }

    private async Task<ProjectItemModel> AddExistingItemAsync(
        Lifetime lifetime,
        AddExistingItemRequest request,
        IProjectFolder parentFolder,
        bool copyBeforeAdd = false)
    {
        var sourcePath = VirtualFileSystemPath.Parse(request.Path, InteractionContext.SolutionContext);
        if (request.IsDirectory && !sourcePath.ExistsDirectory || !request.IsDirectory && !sourcePath.ExistsFile)
            throw new InvalidOperationException("Cannot add non-existing item");

        if (sourcePath.Equals(parentFolder.Location))
            throw new InvalidOperationException("Cannot add item to itself");
        if (sourcePath.IsPrefixOf(parentFolder.Location))
            throw new InvalidOperationException("Cannot add item to its subfolder");

        if (copyBeforeAdd)
        {
            var destinationPath = parentFolder.Location / sourcePath.Name;
            _logger.Trace($"Copying {sourcePath} to {destinationPath}");

            try
            {
                sourcePath.Copy(destinationPath, false);
            }
            catch (Exception e)
            {
                _logger.Error(e, $"Failed to copy {sourcePath} to {destinationPath}");
                throw new IOException("Failed to copy the item");
            }

            sourcePath = destinationPath;
        }

        _logger.Trace($"Adding existing item from '{sourcePath}' to '{parentFolder.Location}'");

        IProjectItem result = null;
        await lifetime.StartMainWrite(() =>
            _solution.InvokeUnderTransaction(cookie =>
            {
                AddItemTaskAction action;
                if (parentFolder.IsSolutionFolder())
                    action = new AddItemInSolutionFolder(lifetime, cookie, parentFolder, sourcePath);
                else if (parentFolder.Location.IsPrefixOf(sourcePath))
                    action = new AddItemPreserveDirectoriesTaskAction(lifetime, cookie, parentFolder, sourcePath);
                else
                    action = new AddItemAsLinkTaskAction(lifetime, cookie, parentFolder, sourcePath);

                // We are not using `IDependsUponProvider` because it requires an already existing `IProjectFile`
                var dependsUponName = GetDependsUponFileName(sourcePath);
                if (dependsUponName is not null)
                    action.Parameters.SetDependentUpon(dependsUponName);

                result = action.Execute();
            }));

        return result is null
            ? null
            : new ProjectItemModel(_host.GetIdByItem(result));
    }
}
