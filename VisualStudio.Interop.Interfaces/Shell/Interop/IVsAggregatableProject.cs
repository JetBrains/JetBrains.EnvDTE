namespace Microsoft.VisualStudio.Shell.Interop;

public interface IVsAggregatableProject
{
  int GetAggregateProjectTypeGuids(out string pbstrProjTypeGuids);
}
