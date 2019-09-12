namespace EnvDTE80
{
	public class CodeModelEventsClass : _CodeModelEvents, CodeModelEvents, _dispCodeModelEvents_Event
	{
		public extern CodeModelEventsClass();
		public virtual extern event _dispCodeModelEvents_ElementAddedEventHandler ElementAdded;
		public virtual extern event _dispCodeModelEvents_ElementChangedEventHandler ElementChanged;
		public virtual extern event _dispCodeModelEvents_ElementDeletedEventHandler ElementDeleted;
	}
}
