namespace EnvDTE80
{
	public class TextDocumentKeyPressEventsClass : _TextDocumentKeyPressEvents, TextDocumentKeyPressEvents,
		_dispTextDocumentKeyPressEvents_Event
	{
		public extern TextDocumentKeyPressEventsClass();
		public virtual extern event _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler BeforeKeyPress;

		public virtual extern void add_BeforeKeyPress(
			_dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler A_1);

		public virtual extern void remove_BeforeKeyPress(
			_dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler A_1);

		public virtual extern event _dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler AfterKeyPress;

		public virtual extern void add_AfterKeyPress(
			_dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler A_1);

		public virtual extern void remove_AfterKeyPress(
			_dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler A_1);
	}
}
