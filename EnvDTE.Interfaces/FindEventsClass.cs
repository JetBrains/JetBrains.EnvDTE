namespace EnvDTE
{
    public class FindEventsClass : _FindEvents, FindEvents, _dispFindEvents_Event
    {
        public FindEventsClass(){ }
        public virtual event _dispFindEvents_FindDoneEventHandler FindDone;
    }
}
