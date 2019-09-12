namespace EnvDTE
{
	public class CommandEventsClass : _CommandEvents, CommandEvents, _dispCommandEvents_Event
	{
		public extern CommandEventsClass();
		public virtual extern event _dispCommandEvents_BeforeExecuteEventHandler BeforeExecute;
		public virtual extern event _dispCommandEvents_AfterExecuteEventHandler AfterExecute;
	}
}
