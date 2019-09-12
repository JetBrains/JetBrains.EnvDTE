namespace EnvDTE
{
	public interface _dispProjectsEvents_Event
	{
		event _dispProjectsEvents_ItemAddedEventHandler ItemAdded;
		event _dispProjectsEvents_ItemRemovedEventHandler ItemRemoved;
		event _dispProjectsEvents_ItemRenamedEventHandler ItemRenamed;
	}
}
