namespace EnvDTE80
{
	public class CodeModelEventsClass : _CodeModelEvents, CodeModelEvents, _dispCodeModelEvents_Event
	{
		public extern CodeModelEventsClass();
		public virtual extern event _dispCodeModelEvents_ElementAddedEventHandler ElementAdded;
		public virtual extern void add_ElementAdded(_dispCodeModelEvents_ElementAddedEventHandler A_1);
		public virtual extern void remove_ElementAdded(_dispCodeModelEvents_ElementAddedEventHandler A_1);
		public virtual extern event _dispCodeModelEvents_ElementChangedEventHandler ElementChanged;

		public virtual extern void add_ElementChanged(
			_dispCodeModelEvents_ElementChangedEventHandler A_1);

		public virtual extern void remove_ElementChanged(
			_dispCodeModelEvents_ElementChangedEventHandler A_1);

		public virtual extern event _dispCodeModelEvents_ElementDeletedEventHandler ElementDeleted;

		public virtual extern void add_ElementDeleted(
			_dispCodeModelEvents_ElementDeletedEventHandler A_1);

		public virtual extern void remove_ElementDeleted(
			_dispCodeModelEvents_ElementDeletedEventHandler A_1);
	}
}
