using System.Collections.Generic;

namespace NuGet.PackageManagement.VisualStudio;

public interface IScriptPackage
{
  string Id { get; }

  string Version { get; }

  IEnumerable<IPackageAssemblyReference> AssemblyReferences { get; }

  IEnumerable<IScriptPackageFile> GetFiles();
}
