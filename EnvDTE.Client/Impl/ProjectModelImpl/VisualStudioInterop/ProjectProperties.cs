using System.Threading.Tasks;
using JetBrains.EnvDTE.Client.Impl;
using JetBrains.Rd.Tasks;
using JetBrains.Rider.Model;

// ReSharper disable once CheckNamespace
namespace Microsoft.VisualStudio.ProjectSystem.Properties;

public class ProjectProperties(DteImplementation dte, ProjectItemModel project) : IProjectProperties
{
  public Task<string> GetEvaluatedPropertyValueAsync(string propertyName) =>
      dte.DteProtocolModel.Project_get_Property.Start(dte.DteLifetime, new(propertyName, project)).AsTask();
}
