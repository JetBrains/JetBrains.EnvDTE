namespace EnvDTE80
{
	public interface _dispTextDocumentKeyPressEvents_Event
	{
		event _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler BeforeKeyPress;

		void add_BeforeKeyPress(
			_dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler A_1);

		void remove_BeforeKeyPress(
			_dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler A_1);

		event _dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler AfterKeyPress;

		void add_AfterKeyPress(
			_dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler A_1);

		void remove_AfterKeyPress(
			_dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler A_1);
	}
}
