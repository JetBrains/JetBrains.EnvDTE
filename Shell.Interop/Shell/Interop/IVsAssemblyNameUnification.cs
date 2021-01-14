namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsAssemblyNameUnification
    {
        int GetUnifiedAssemblyName(
             string wszFrameworkDirectory,
             string wszSimpleAssemblyName,
             string wszFullAssemblyName,
             out string pbstrUnifiedAssemblyName);
    }
}
