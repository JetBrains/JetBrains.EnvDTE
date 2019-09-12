namespace EnvDTE80
{
	public class PublishEventsClass : _PublishEvents, PublishEvents, _dispPublishEvents_Event
	{
		public extern PublishEventsClass();
		public virtual extern event _dispPublishEvents_OnPublishBeginEventHandler OnPublishBegin;
		public virtual extern void add_OnPublishBegin(_dispPublishEvents_OnPublishBeginEventHandler A_1);

		public virtual extern void remove_OnPublishBegin(
			_dispPublishEvents_OnPublishBeginEventHandler A_1);

		public virtual extern event _dispPublishEvents_OnPublishDoneEventHandler OnPublishDone;
		public virtual extern void add_OnPublishDone(_dispPublishEvents_OnPublishDoneEventHandler A_1);
		public virtual extern void remove_OnPublishDone(_dispPublishEvents_OnPublishDoneEventHandler A_1);
	}
}
