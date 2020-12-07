namespace EnvDTE
{
    public class CommandBarEventsClass : _CommandBarControlEvents, CommandBarEvents, _dispCommandBarControlEvents_Event
    {
        public CommandBarEventsClass(){ }
        public virtual event _dispCommandBarControlEvents_ClickEventHandler Click;
    }
}
