using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.Components;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.impl;
using JetBrains.ProjectModel.Impl;
using JetBrains.ProjectModel.ProjectsHost;
using JetBrains.ProjectModel.ProjectsHost.Impl;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost;
using JetBrains.ProjectModel.ProjectsHost.SolutionHost.Impl;
using JetBrains.ProjectModel.SolutionStructure.SolutionConfigurations;
using JetBrains.ProjectModel.SolutionStructure.SolutionDefinitions;
using JetBrains.Rd.Base;
using JetBrains.RdBackend.Common.Features.ProjectModel;
using JetBrains.Util.Logging;

namespace JetBrains.EnvDTE.Host.Callback.Util;

public static class SolutionExtensions
{
    const string InvalidSolutionConfigurationMessage = "Invalid solution configuration";
    private const string SolutionDescriptionPropertyName = "Description";

    // TODO: Get/Set Description doesn't work for slnx solutions
    [CanBeNull]
    public static string GetSolutionDescription([NotNull] this ISolutionMark solutionMark)
    {
        TryGetOrCreateSolutionDescriptionSection(solutionMark, out _, out var property);
        return property?.PropertyValue;
    }

    public static void SetSolutionDescription([NotNull] this ISolution solution, [CanBeNull] string value)
    {
        var solutionMark = solution.GetSolutionMark();
        if (solutionMark is null) return;

        if (!TryGetOrCreateSolutionDescriptionSection(solutionMark, out var section, out var property)) return;

        if (property is null)
        {
            if (value is not null) section.AddProperty(SolutionDescriptionPropertyName, value);
        }
        else
        {
            if (value is null) section.RemoveProperty(property);
            else section.UpdateProperty(property, SolutionDescriptionPropertyName, value);
        }

        var host = solution.ProjectsHostContainer().GetComponent<SolutionHost>();
        host.Persist();
    }

    public static void RenameSolution([NotNull] this ISolution solution, [CanBeNull] string newName)
    {
        if (string.IsNullOrWhiteSpace(newName) || newName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            throw new ArgumentException("Solution name contains invalid characters.");

        newName += solution.SolutionFilePath.ExtensionWithDot;
        try
        {
            var newPath = solution.SolutionFilePath.Directory.Combine(newName);
            solution.SolutionFilePath.Move(newPath);
        }
        catch (Exception e)
        {
            Logger.LogException($"Failed to rename solution file to {newName}", e);
            throw new IOException("Failed to rename the solution file.");
        }

        solution.InvokeUnderTransaction(_ =>
        {
            if (solution.GetSolutionMark() is SolutionMark solutionMark) solutionMark.RenameSolution(newName);

            ((SolutionElement)solution).RenameSolutionFile(new SolutionLocation(
                solution.SolutionDirectory, solution.SolutionDirectory.Combine(newName)
            ));
        });
    }

    public static void SetActiveConfigurationAndPlatform([NotNull] this ISolution solution,
        [NotNull] SolutionConfigurationAndPlatform configuration)
    {
        var solutionMark = solution.GetSolutionMark();
        if (solutionMark is null) return;

        if (!solutionMark.ConfigurationAndPlatformStore.ConfigurationsAndPlatforms.Contains(configuration))
            throw new ArgumentException(InvalidSolutionConfigurationMessage);

        var activeConfigurationManager = solution.GetComponent<IActiveConfigurationManager>();
        activeConfigurationManager.ActiveConfigurationAndPlatform.SetValue(configuration);
    }

    public static void SetActiveConfigurationAndPlatform([NotNull] this ISolution solution, [CanBeNull] string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(InvalidSolutionConfigurationMessage);

        var parts = value.Split('|');
        if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
            throw new ArgumentException(InvalidSolutionConfigurationMessage);

        var config = new SolutionConfigurationAndPlatform(parts[0], parts[1]);
        solution.SetActiveConfigurationAndPlatform(config);
    }

    private static bool TryGetOrCreateSolutionDescriptionSection(ISolutionMark solutionMark, out SectionDefinition section,
        out PropertyDefinition property)
    {
        if (solutionMark is not SolutionMark { Definition: SolutionDefinition definition })
        {
            section = null;
            property = null;
            return false;
        }

        section = definition.GetOrCreateGlobalSection("SolutionConfigurationPlatforms", "preSolution");
        property = section.GetProperties(SolutionDescriptionPropertyName).SingleOrDefault();

        return true;
    }
}
