namespace EnvDTE80
{
    public class PublishEventsClass : _PublishEvents, PublishEvents, _dispPublishEvents_Event
    {
        public PublishEventsClass(){ }
        public virtual event _dispPublishEvents_OnPublishBeginEventHandler OnPublishBegin;
        public virtual event _dispPublishEvents_OnPublishDoneEventHandler OnPublishDone;
    }
}
