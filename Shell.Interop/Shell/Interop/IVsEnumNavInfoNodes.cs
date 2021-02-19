namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsEnumNavInfoNodes
    {
        int Next(uint celt, IVsNavInfoNode[] rgelt, out uint pceltFetched);

        int Skip(uint celt);

        int Reset();

        int Clone(out IVsEnumNavInfoNodes ppEnum);
    }
}
