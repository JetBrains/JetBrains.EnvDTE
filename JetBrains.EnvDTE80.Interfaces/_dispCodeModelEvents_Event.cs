namespace EnvDTE80
{
	public interface _dispCodeModelEvents_Event
	{
		event _dispCodeModelEvents_ElementAddedEventHandler ElementAdded;
		void add_ElementAdded(_dispCodeModelEvents_ElementAddedEventHandler A_1);
		void remove_ElementAdded(_dispCodeModelEvents_ElementAddedEventHandler A_1);
		event _dispCodeModelEvents_ElementChangedEventHandler ElementChanged;

		void add_ElementChanged(
			_dispCodeModelEvents_ElementChangedEventHandler A_1);

		void remove_ElementChanged(
			_dispCodeModelEvents_ElementChangedEventHandler A_1);

		event _dispCodeModelEvents_ElementDeletedEventHandler ElementDeleted;

		void add_ElementDeleted(
			_dispCodeModelEvents_ElementDeletedEventHandler A_1);

		void remove_ElementDeleted(
			_dispCodeModelEvents_ElementDeletedEventHandler A_1);
	}
}
