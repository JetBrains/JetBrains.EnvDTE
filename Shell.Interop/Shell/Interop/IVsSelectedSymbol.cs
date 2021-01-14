namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSelectedSymbol
    {
        int GetNavInfo(out IVsNavInfo ppNavInfo);

        int GetName(out string pbstrName);
    }
}
