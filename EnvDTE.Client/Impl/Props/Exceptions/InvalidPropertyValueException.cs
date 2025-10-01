using System;
using JetBrains.Annotations;

namespace JetBrains.EnvDTE.Client.Impl.Props.Exceptions;

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
