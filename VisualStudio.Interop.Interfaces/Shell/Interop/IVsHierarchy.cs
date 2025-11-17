namespace Microsoft.VisualStudio.Shell.Interop;

public interface IVsHierarchy
{
  int GetProperty(uint itemid, int propid, out object pvar);
}
