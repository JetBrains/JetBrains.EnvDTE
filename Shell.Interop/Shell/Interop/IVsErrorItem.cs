namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsErrorItem
    {
        int GetHierarchy(out object ppProject);

        int GetCategory(out uint pCategory);
    }
}
