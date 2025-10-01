using System;

namespace JetBrains.EnvDTE.Client.Impl.Props.Exceptions;

[Serializable]
public class SetReadOnlyPropertyException()
    : InvalidOperationException("Can't set the value of a read-only property.");
