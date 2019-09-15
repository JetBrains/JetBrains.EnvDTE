namespace EnvDTE
{
    public class FindEventsClass : _FindEvents, FindEvents, _dispFindEvents_Event
    {
        public extern FindEventsClass();
        public virtual extern event _dispFindEvents_FindDoneEventHandler FindDone;
    }
}
