using System;

namespace JetBrains.EnvDTE.Client.Impl.PropertyImpl.Exceptions;

[Serializable]
public class InvalidEnumPropertyValueException()
    : InvalidPropertyValueException("The value must be a string denoting the name of one of the valid values" +
                                    " or an integer denoting the index of one of the valid values.");
