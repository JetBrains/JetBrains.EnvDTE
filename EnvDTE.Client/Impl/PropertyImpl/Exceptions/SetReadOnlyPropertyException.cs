using System;

namespace JetBrains.EnvDTE.Client.Impl.PropertyImpl.Exceptions;

[Serializable]
public class SetReadOnlyPropertyException()
    : InvalidOperationException("Can't set the value of a read-only property.");
