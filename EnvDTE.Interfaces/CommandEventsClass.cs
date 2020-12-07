namespace EnvDTE
{
    public class CommandEventsClass : _CommandEvents, CommandEvents, _dispCommandEvents_Event
    {
        public CommandEventsClass(){ }
        public virtual event _dispCommandEvents_BeforeExecuteEventHandler BeforeExecute;
        public virtual event _dispCommandEvents_AfterExecuteEventHandler AfterExecute;
    }
}
