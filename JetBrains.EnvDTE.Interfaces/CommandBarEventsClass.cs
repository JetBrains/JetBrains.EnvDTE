namespace EnvDTE
{
	public class CommandBarEventsClass : _CommandBarControlEvents, CommandBarEvents, _dispCommandBarControlEvents_Event
	{
		public extern CommandBarEventsClass();
		public virtual extern event _dispCommandBarControlEvents_ClickEventHandler Click;
		public virtual extern void add_Click(_dispCommandBarControlEvents_ClickEventHandler A_1);
		public virtual extern void remove_Click(_dispCommandBarControlEvents_ClickEventHandler A_1);
	}
}
