namespace EnvDTE
{
    public class ProjectItemsEventsClass : _ProjectItemsEvents, ProjectItemsEvents, _dispProjectItemsEvents_Event
    {
        public ProjectItemsEventsClass(){ }
        public virtual event _dispProjectItemsEvents_ItemAddedEventHandler ItemAdded;
        public virtual event _dispProjectItemsEvents_ItemRemovedEventHandler ItemRemoved;
        public virtual event _dispProjectItemsEvents_ItemRenamedEventHandler ItemRenamed;
    }
}
