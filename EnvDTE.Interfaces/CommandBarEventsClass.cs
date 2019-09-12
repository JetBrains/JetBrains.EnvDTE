namespace EnvDTE
{
	public class CommandBarEventsClass : _CommandBarControlEvents, CommandBarEvents, _dispCommandBarControlEvents_Event
	{
		public extern CommandBarEventsClass();
		public virtual extern event _dispCommandBarControlEvents_ClickEventHandler Click;
	}
}
