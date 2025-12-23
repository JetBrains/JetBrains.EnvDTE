using System;

namespace JetBrains.EnvDTE.Client.Util;

public static class ImplementationUtil
{
    public static int GetValidIndexOrThrow(object index, int? count = null)
    {
        if (index is not int number) throw new ArgumentException();
        // Indexes are 1-based in EnvDTE
        if (number < 1 || number > count) throw new ArgumentOutOfRangeException();
        return number - 1;
    }
}
