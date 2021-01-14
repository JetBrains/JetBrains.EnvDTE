namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccGlyphs
    {
        int GetCustomGlyphList(uint BaseIndex, out uint pdwImageListHandle);
    }
}
