namespace EnvDTE
{
	public class FindEventsClass : _FindEvents, FindEvents, _dispFindEvents_Event
	{
		public extern FindEventsClass();
		public virtual extern event _dispFindEvents_FindDoneEventHandler FindDone;
		public virtual extern void add_FindDone(_dispFindEvents_FindDoneEventHandler A_1);
		public virtual extern void remove_FindDone(_dispFindEvents_FindDoneEventHandler A_1);
	}
}
