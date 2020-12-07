namespace EnvDTE80
{
    public class TextDocumentKeyPressEventsClass : _TextDocumentKeyPressEvents, TextDocumentKeyPressEvents,
        _dispTextDocumentKeyPressEvents_Event
    {
        public TextDocumentKeyPressEventsClass(){ }
        public virtual event _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler BeforeKeyPress;
        public virtual event _dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler AfterKeyPress;
    }
}
