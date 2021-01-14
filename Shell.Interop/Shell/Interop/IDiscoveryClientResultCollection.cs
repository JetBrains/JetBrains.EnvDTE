namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IDiscoveryClientResultCollection
    {
        int GetResultCount(out int pCount);

        int GetResult(
            int pIndex,
            out IDiscoveryClientResult ppIDiscoveryClientResult);
    }
}
