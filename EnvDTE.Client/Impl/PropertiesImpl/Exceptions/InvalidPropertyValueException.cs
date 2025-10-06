using System;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.PropertiesImpl.Exceptions;

[Serializable]
public class InvalidPropertyValueException : Exception
{
    private const string DefaultMessage = "Invalid property value";

    public InvalidPropertyValueException() : base(DefaultMessage)
    {

    }

    public InvalidPropertyValueException([NotNull] string message) : base($"{DefaultMessage}: {message}")
    {

    }
}
