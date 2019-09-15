namespace EnvDTE
{
    public interface _dispProjectsEvents
    {
        void ItemAdded(Project Project);
        void ItemRemoved(Project Project);
        void ItemRenamed(Project Project, string OldName);
    }
}
