using System;

namespace Microsoft.VisualStudio.ComponentModelHost;

public interface IComponentModel
{
  object GetService(Type type);
}
