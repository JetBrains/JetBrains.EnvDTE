using System.Threading.Tasks;

namespace Microsoft.VisualStudio.ProjectSystem.Properties;

public interface IProjectProperties
{
  Task<string> GetEvaluatedPropertyValueAsync(string propertyName);
}
