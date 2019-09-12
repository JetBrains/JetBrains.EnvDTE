namespace EnvDTE
{
	public class ProjectsEventsClass : _ProjectsEvents, ProjectsEvents, _dispProjectsEvents_Event
	{
		public extern ProjectsEventsClass();
		public virtual extern event _dispProjectsEvents_ItemAddedEventHandler ItemAdded;
		public virtual extern void add_ItemAdded(_dispProjectsEvents_ItemAddedEventHandler A_1);
		public virtual extern void remove_ItemAdded(_dispProjectsEvents_ItemAddedEventHandler A_1);
		public virtual extern event _dispProjectsEvents_ItemRemovedEventHandler ItemRemoved;
		public virtual extern void add_ItemRemoved(_dispProjectsEvents_ItemRemovedEventHandler A_1);
		public virtual extern void remove_ItemRemoved(_dispProjectsEvents_ItemRemovedEventHandler A_1);
		public virtual extern event _dispProjectsEvents_ItemRenamedEventHandler ItemRenamed;
		public virtual extern void add_ItemRenamed(_dispProjectsEvents_ItemRenamedEventHandler A_1);
		public virtual extern void remove_ItemRenamed(_dispProjectsEvents_ItemRenamedEventHandler A_1);
	}
}
