namespace EnvDTE
{
    public interface _dispSolutionEvents
    {
        void Opened();
        void BeforeClosing();
        void AfterClosing();
        void QueryCloseSolution(ref bool fCancel);
        void Renamed(string OldName);
        void ProjectAdded(Project Project);
        void ProjectRemoved(Project Project);
        void ProjectRenamed(Project Project, string OldName);
    }
}
