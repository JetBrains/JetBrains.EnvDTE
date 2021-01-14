namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsPrioritizedSolutionEvents
    {
        int PrioritizedOnAfterOpenProject(object pHierarchy, int fAdded);

        int PrioritizedOnBeforeCloseProject(object pHierarchy, int fRemoved);

        int PrioritizedOnAfterLoadProject(object pStubHierarchy, object pRealHierarchy);

        int PrioritizedOnBeforeUnloadProject(object pRealHierarchy, object pStubHierarchy);

        int PrioritizedOnAfterOpenSolution(object pUnkReserved, int fNewSolution);

        int PrioritizedOnBeforeCloseSolution(object pUnkReserved);

        int PrioritizedOnAfterCloseSolution(object pUnkReserved);

        int PrioritizedOnAfterMergeSolution(object pUnkReserved);

        int PrioritizedOnBeforeOpeningChildren(object pHierarchy);

        int PrioritizedOnAfterOpeningChildren(object pHierarchy);

        int PrioritizedOnBeforeClosingChildren(object pHierarchy);

        int PrioritizedOnAfterClosingChildren(object pHierarchy);

        int PrioritizedOnAfterRenameProject(object pHierarchy);

        int PrioritizedOnAfterChangeProjectParent(object pHierarchy);

        int PrioritizedOnAfterAsynchOpenProject(object pHierarchy, int fAdded);
    }
}
