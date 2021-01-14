namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsEnumSelectedSymbols
    {
        int Next(uint celt, IVsSelectedSymbol[] rgpIVsSelectedSymbol, out uint pceltFetched);

        int Skip(uint celt);

        int Reset();

        int Clone(out IVsEnumSelectedSymbols ppIVsEnumSelectedSymbols);
    }
}
