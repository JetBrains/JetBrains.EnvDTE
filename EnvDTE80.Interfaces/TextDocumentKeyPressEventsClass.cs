namespace EnvDTE80
{
    public class TextDocumentKeyPressEventsClass : _TextDocumentKeyPressEvents, TextDocumentKeyPressEvents,
        _dispTextDocumentKeyPressEvents_Event
    {
        public extern TextDocumentKeyPressEventsClass();
        public virtual extern event _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler BeforeKeyPress;
        public virtual extern event _dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler AfterKeyPress;
    }
}
