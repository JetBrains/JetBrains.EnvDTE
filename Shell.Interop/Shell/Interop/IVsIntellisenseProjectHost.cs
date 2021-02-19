namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsIntellisenseProjectHost
    {
        int GetHostProperty(uint dwPropID, out object pvar);

        int GetCompilerOptions(out string pbstrOptions);

        int GetOutputAssembly(out string pbstrOutputAssembly);

        int CreateFileCodeModel(string pszFilename, out object ppCodeModel);
    }
}
