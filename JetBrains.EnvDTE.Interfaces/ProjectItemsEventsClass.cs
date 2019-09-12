namespace EnvDTE
{
	public class ProjectItemsEventsClass : _ProjectItemsEvents, ProjectItemsEvents, _dispProjectItemsEvents_Event
	{
		public extern ProjectItemsEventsClass();
		public virtual extern event _dispProjectItemsEvents_ItemAddedEventHandler ItemAdded;
		public virtual extern void add_ItemAdded(_dispProjectItemsEvents_ItemAddedEventHandler A_1);
		public virtual extern void remove_ItemAdded(_dispProjectItemsEvents_ItemAddedEventHandler A_1);
		public virtual extern event _dispProjectItemsEvents_ItemRemovedEventHandler ItemRemoved;

		public virtual extern void add_ItemRemoved(
			_dispProjectItemsEvents_ItemRemovedEventHandler A_1);

		public virtual extern void remove_ItemRemoved(
			_dispProjectItemsEvents_ItemRemovedEventHandler A_1);

		public virtual extern event _dispProjectItemsEvents_ItemRenamedEventHandler ItemRenamed;

		public virtual extern void add_ItemRenamed(
			_dispProjectItemsEvents_ItemRenamedEventHandler A_1);

		public virtual extern void remove_ItemRenamed(
			_dispProjectItemsEvents_ItemRenamedEventHandler A_1);
	}
}
