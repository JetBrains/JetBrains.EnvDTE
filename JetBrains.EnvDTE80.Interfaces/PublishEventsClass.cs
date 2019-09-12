namespace EnvDTE80
{
	public class PublishEventsClass : _PublishEvents, PublishEvents, _dispPublishEvents_Event
	{
		public extern PublishEventsClass();
		public virtual extern event _dispPublishEvents_OnPublishBeginEventHandler OnPublishBegin;
		public virtual extern event _dispPublishEvents_OnPublishDoneEventHandler OnPublishDone;
	}
}
