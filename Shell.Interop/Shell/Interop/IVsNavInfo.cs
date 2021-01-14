using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsNavInfo
    {
        int GetLibGuid(out Guid pGuid);

        int GetSymbolType(out uint pdwType);

        int EnumPresentationNodes(uint dwFlags, out IVsEnumNavInfoNodes ppEnum);

        int EnumCanonicalNodes(out IVsEnumNavInfoNodes ppEnum);
    }
}
