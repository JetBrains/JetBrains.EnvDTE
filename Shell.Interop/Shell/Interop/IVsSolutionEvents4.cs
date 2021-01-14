namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSolutionEvents4
    {
        int OnAfterRenameProject(object pHierarchy);


        int OnQueryChangeProjectParent(
            object pHierarchy,
            object pNewParentHier,
            ref int pfCancel);


        int OnAfterChangeProjectParent(object pHierarchy);


        int OnAfterAsynchOpenProject(object pHierarchy, int fAdded);
    }
}
