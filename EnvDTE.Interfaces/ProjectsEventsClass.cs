namespace EnvDTE
{
    public class ProjectsEventsClass : _ProjectsEvents, ProjectsEvents, _dispProjectsEvents_Event
    {
        public ProjectsEventsClass(){}
        public virtual event _dispProjectsEvents_ItemAddedEventHandler ItemAdded;
        public virtual event _dispProjectsEvents_ItemRemovedEventHandler ItemRemoved;
        public virtual event _dispProjectsEvents_ItemRenamedEventHandler ItemRenamed;
    }
}
