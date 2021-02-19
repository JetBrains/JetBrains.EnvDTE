namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsEnumCryptoProviders
    {
        int Next(uint celt, string[] pbstrProviders, out uint pceltFetched);

        int Reset();
    }
}
