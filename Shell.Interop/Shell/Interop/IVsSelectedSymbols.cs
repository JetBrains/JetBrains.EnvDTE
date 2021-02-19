namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSelectedSymbols
    {
        int GetCount(out uint pcItems);

        int GetItem(uint iItem, out IVsSelectedSymbol ppIVsSelectedSymbol);

        int EnumSelectedSymbols(out IVsEnumSelectedSymbols ppIVsEnumSelectedSymbols);

        int GetItemTypes(out uint pgrfTypes);
    }
}
