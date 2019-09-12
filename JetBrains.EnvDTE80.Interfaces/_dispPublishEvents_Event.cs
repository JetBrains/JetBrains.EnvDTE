namespace EnvDTE80
{
	public interface _dispPublishEvents_Event
	{
		event _dispPublishEvents_OnPublishBeginEventHandler OnPublishBegin;
		void add_OnPublishBegin(_dispPublishEvents_OnPublishBeginEventHandler A_1);
		void remove_OnPublishBegin(_dispPublishEvents_OnPublishBeginEventHandler A_1);
		event _dispPublishEvents_OnPublishDoneEventHandler OnPublishDone;
		void add_OnPublishDone(_dispPublishEvents_OnPublishDoneEventHandler A_1);
		void remove_OnPublishDone(_dispPublishEvents_OnPublishDoneEventHandler A_1);
	}
}
