namespace EnvDTE
{
    public class ProjectItemsEventsClass : _ProjectItemsEvents, ProjectItemsEvents, _dispProjectItemsEvents_Event
    {
        public extern ProjectItemsEventsClass();
        public virtual extern event _dispProjectItemsEvents_ItemAddedEventHandler ItemAdded;
        public virtual extern event _dispProjectItemsEvents_ItemRemovedEventHandler ItemRemoved;
        public virtual extern event _dispProjectItemsEvents_ItemRenamedEventHandler ItemRenamed;
    }
}
