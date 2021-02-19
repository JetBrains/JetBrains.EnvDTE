namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsContextualIntellisenseFilterProvider
    {
        int GetFilter(object pHierarchy, out IVsContextualIntellisenseFilter ppFilter);
    }
}
