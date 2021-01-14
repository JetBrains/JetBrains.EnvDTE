namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsEnumLibraries2
    {
        int Next(uint celt, IVsLibrary2[] rgelt, out uint pceltFetched);

        int Skip(uint celt);

        int Reset();

        int Clone(out IVsEnumLibraries2 ppEnum);
    }
}
