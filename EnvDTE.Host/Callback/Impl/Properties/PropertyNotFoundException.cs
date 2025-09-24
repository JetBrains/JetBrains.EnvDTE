using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Host.Callback.Impl.Properties;

[Serializable]
public class PropertyNotFoundException([NotNull] string propertyName)
    : KeyNotFoundException($"Property '{propertyName}' not found");
