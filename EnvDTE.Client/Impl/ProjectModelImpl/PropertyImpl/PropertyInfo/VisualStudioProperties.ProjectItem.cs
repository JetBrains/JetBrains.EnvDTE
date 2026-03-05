using System.Collections.Generic;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Impl.ProjectModelImpl.PropertyImpl.PropertyInfo;

// TODO: Implement these fully - Right now they MsBuild metadata properties are not supported
internal static partial class VisualStudioProperties
{
    // Some common properties for files - mainly related to the file system
    internal static readonly IReadOnlyDictionary<string, StringPropertyInfo> CommonProjectItemFilePropertiesMap =
        new Dictionary<string, StringPropertyInfo>
        {
            ["DateCreated"] = new("DateCreated", "DateCreated", true),
            ["DateModified"] = new("DateModified", "DateModified", true),
            ["Extension"] = new("Extension", "Extension", true),
            ["FileName"] = new("FileName", "FileName", true),
            ["Filesize"] = new("Filesize", "FileSize", true),
            ["LocalPath"] = new("LocalPath", "LocalPath", true),
            ["FullPath"] = new("FullPath", "FullPath", true)
        };

    // Some common properties for folders - mainly related to the file system
    internal static readonly IReadOnlyDictionary<string, StringPropertyInfo> CommonProjectItemFolderPropertiesMap =
        new Dictionary<string, StringPropertyInfo>
        {
            ["FileName"] = new("FileName", "FileName", true),
            ["LocalPath"] = new("LocalPath", "LocalPath", true),
            ["FullPath"] = new("FullPath", "FullPath", true)
        };

    internal static IReadOnlyDictionary<string, StringPropertyInfo> GetItemKindSpecificMap(ProjectItemKindModel itemKind) =>
        itemKind switch
        {
            ProjectItemKindModel.PhysicalFile => CommonProjectItemFilePropertiesMap,
            ProjectItemKindModel.PhysicalFolder => CommonProjectItemFolderPropertiesMap,
            _ => new Dictionary<string, StringPropertyInfo>()
        };
}
