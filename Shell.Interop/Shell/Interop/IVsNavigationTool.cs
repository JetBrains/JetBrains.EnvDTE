using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsNavigationTool
    {
        int NavigateToSymbol(ref Guid guidLib, object[] rgSymbolNodes, uint ulcNodes);

        int NavigateToNavInfo(IVsNavInfo pNavInfo);

        int GetSelectedSymbols(out IVsSelectedSymbols ppIVsSelectedSymbols);
    }
}
