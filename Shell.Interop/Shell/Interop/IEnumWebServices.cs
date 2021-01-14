namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IEnumWebServices
    {
        int Next(uint celt, IVsWebService[] rgelt, out uint pceltFetched);

        int Skip(uint celt);

        int Reset();

        int Clone(out IEnumWebServices ppEnum);
    }
}
