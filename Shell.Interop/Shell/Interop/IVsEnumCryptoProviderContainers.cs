namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsEnumCryptoProviderContainers
    {
        int Next(uint celt, string[] pbstrContainers, out uint pceltFetched);

        int Reset();
    }
}
