namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccEnlistmentPathTranslation
    {
        int TranslateProjectPathToEnlistmentPath(
            string lpszProjectPath,
            out string pbstrEnlistmentPath,
            out string pbstrEnlistmentPathUNC);

        int TranslateEnlistmentPathToProjectPath(string lpszEnlistmentPath, out string pbstrProjectPath);
    }
}
