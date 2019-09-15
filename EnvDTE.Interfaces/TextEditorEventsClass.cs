namespace EnvDTE
{
    public class TextEditorEventsClass : _TextEditorEvents, TextEditorEvents, _dispTextEditorEvents_Event
    {
        public extern TextEditorEventsClass();
        public virtual extern event _dispTextEditorEvents_LineChangedEventHandler LineChanged;
    }
}
