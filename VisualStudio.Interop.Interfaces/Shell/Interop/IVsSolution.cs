namespace Microsoft.VisualStudio.Shell.Interop;

public interface IVsSolution
{
  int GetProjectOfUniqueName(string pszUniqueName, out IVsHierarchy ppHierarchy);
}
