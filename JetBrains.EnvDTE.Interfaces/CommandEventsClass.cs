namespace EnvDTE
{
	public class CommandEventsClass : _CommandEvents, CommandEvents, _dispCommandEvents_Event
	{
		public extern CommandEventsClass();
		public virtual extern event _dispCommandEvents_BeforeExecuteEventHandler BeforeExecute;
		public virtual extern void add_BeforeExecute(_dispCommandEvents_BeforeExecuteEventHandler A_1);
		public virtual extern void remove_BeforeExecute(_dispCommandEvents_BeforeExecuteEventHandler A_1);
		public virtual extern event _dispCommandEvents_AfterExecuteEventHandler AfterExecute;
		public virtual extern void add_AfterExecute(_dispCommandEvents_AfterExecuteEventHandler A_1);
		public virtual extern void remove_AfterExecute(_dispCommandEvents_AfterExecuteEventHandler A_1);
	}
}
