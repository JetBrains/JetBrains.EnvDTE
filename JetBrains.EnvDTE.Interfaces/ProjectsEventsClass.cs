namespace EnvDTE
{
	public class ProjectsEventsClass : _ProjectsEvents, ProjectsEvents, _dispProjectsEvents_Event
	{
		public extern ProjectsEventsClass();
		public virtual extern event _dispProjectsEvents_ItemAddedEventHandler ItemAdded;
		public virtual extern event _dispProjectsEvents_ItemRemovedEventHandler ItemRemoved;
		public virtual extern event _dispProjectsEvents_ItemRenamedEventHandler ItemRenamed;
	}
}
