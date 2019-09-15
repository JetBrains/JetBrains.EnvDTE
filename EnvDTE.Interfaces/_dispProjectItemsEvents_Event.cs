namespace EnvDTE
{
    public interface _dispProjectItemsEvents_Event
    {
        event _dispProjectItemsEvents_ItemAddedEventHandler ItemAdded;
        event _dispProjectItemsEvents_ItemRemovedEventHandler ItemRemoved;
        event _dispProjectItemsEvents_ItemRenamedEventHandler ItemRenamed;
    }
}
