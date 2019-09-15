namespace EnvDTE
{
    public interface _dispProjectItemsEvents
    {
        void ItemAdded(ProjectItem ProjectItem);
        void ItemRemoved(ProjectItem ProjectItem);
        void ItemRenamed(ProjectItem ProjectItem, string OldName);
    }
}
